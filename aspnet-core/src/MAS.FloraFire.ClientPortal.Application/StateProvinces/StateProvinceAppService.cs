using MAS.FloraFire.ClientPortal.Countries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.StateProvinces
{
    public class StateProvinceAppService : ApplicationService, IStateProvinceAppService
    {
        #region Fields

        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<StateProvince> _stateProvinceRepository;

        #endregion

        #region Ctor

        public StateProvinceAppService(
            IRepository<Country> countryRepository,
            IRepository<StateProvince> stateProvinceRepository)
        {
            _countryRepository = countryRepository;
            _stateProvinceRepository = stateProvinceRepository;
        }

        #endregion

        #region Methods

        public async Task<StateProvinceDto> GetAsync(Guid id)
        {
            var queryResult = await _stateProvinceRepository.FindAsync(x => x.Id == id);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(StateProvince), id);
            }

            var stateProvinceDto = ObjectMapper.Map<StateProvince, StateProvinceDto>(queryResult);
            return stateProvinceDto;
        }

        public async Task<ListResultDto<StateProvinceDto>> GetListAsync()
        {
            var stateProvinces = await _stateProvinceRepository.GetListAsync();

            return new ListResultDto<StateProvinceDto>(
                ObjectMapper.Map<List<StateProvince>, List<StateProvinceDto>>(stateProvinces)
            );
        }

        public async Task<StateProvinceDto> GetStateProvinceByAbbreviationAsync(string abbreviation, Guid? countryId = null)
        {
            var query = await _stateProvinceRepository.GetQueryableAsync();

            query = query.Where(x => x.Abbreviation == abbreviation);

            if (countryId.HasValue)
                query = query.Where(state => state.CountryId == countryId);

            var stateProvince = await query.FirstOrDefaultAsync();

            if (stateProvince == null)
                throw new EntityNotFoundException(typeof(StateProvince), abbreviation);

            return ObjectMapper.Map<StateProvince, StateProvinceDto>(stateProvince);
        }

        public virtual async Task<ListResultDto<StateProvinceDto>> GetStateProvincesByCountryIdAsync(Guid countryId, bool showHidden = false)
        {
            var query = from sp in await _stateProvinceRepository.GetQueryableAsync()
                        orderby sp.DisplayOrder, sp.Name
                        where sp.CountryId == countryId &&
                        (showHidden || sp.Published)
                        select sp;

            var stateProvinces = await query.ToListAsync();

            return new ListResultDto<StateProvinceDto>(
               ObjectMapper.Map<List<StateProvince>, List<StateProvinceDto>>(stateProvinces)
           );

        }

        public async Task<ListResultDto<StateProvinceLookupDto>> GetStateProvinceLookupAsync()
        {
            var stateProvinces = await _stateProvinceRepository.GetListAsync();

            return new ListResultDto<StateProvinceLookupDto>(
                ObjectMapper.Map<List<StateProvince>, List<StateProvinceLookupDto>>(stateProvinces)
            );
        }

        public async Task<List<StateProvinceDto>> GetByIdsAsync(Guid[] ids)
        {
            if (ids == null || ids.Length == 0)
                return new List<StateProvinceDto>();

            var stateProvinces = await _stateProvinceRepository.GetListAsync(c => ids.Contains(c.Id));

            var stateProvinceDtos = ObjectMapper.Map<List<StateProvince>, List<StateProvinceDto>>(stateProvinces);

            return stateProvinceDtos;
        }

        #endregion
    }
}