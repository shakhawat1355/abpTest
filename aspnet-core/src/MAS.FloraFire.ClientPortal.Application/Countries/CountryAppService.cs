using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.Countries
{
    public class CountryAppService : ApplicationService, ICountryAppService
    {
        #region Fields

        private readonly IRepository<Country> _countryRepository;

        #endregion

        #region Ctor

        public CountryAppService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        #endregion

        #region Methods

        public async Task<CountryDto> GetAsync(Guid id)
        {
            var queryResult = await _countryRepository.FindAsync(x => x.Id == id);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Country), id);
            }

            var countryDto = ObjectMapper.Map<Country, CountryDto>(queryResult);
            return countryDto;
        }

        public async Task<ListResultDto<CountryDto>> GetListAsync()
        {
            var countries = await _countryRepository.GetListAsync();

            return new ListResultDto<CountryDto>(
                ObjectMapper.Map<List<Country>, List<CountryDto>>(countries)
            );
        }

        public async Task<CountryDto> FromCountryCode(string countryCode)
        {
            var country = await _countryRepository
                           .FirstOrDefaultAsync(x => x.TwoLetterIsoCode == countryCode);

            if (country == null)
                throw new EntityNotFoundException(typeof(Country), countryCode);

            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        public async Task<ListResultDto<CountryLookupDto>> GetCountryLookupAsync()
        {
            var countries = await _countryRepository.GetListAsync();

            return new ListResultDto<CountryLookupDto>(
                ObjectMapper.Map<List<Country>, List<CountryLookupDto>>(countries.OrderBy(c => c.Name).ToList())
            );
        }

        public async Task<List<CountryDto>> GetByIdsAsync(Guid[] ids)
        {
            if (ids == null || ids.Length == 0)
                return new List<CountryDto>();

            var countries = await _countryRepository.GetListAsync(c => ids.Contains(c.Id));

            var countryDtos = ObjectMapper.Map<List<Country>, List<CountryDto>>(countries);

            return countryDtos;
        }

        #endregion
    }
}
