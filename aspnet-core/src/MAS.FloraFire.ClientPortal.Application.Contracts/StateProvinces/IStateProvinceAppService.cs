using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.StateProvinces
{
    public interface IStateProvinceAppService : IApplicationService
    {
        Task<StateProvinceDto> GetAsync(Guid id);
        Task<ListResultDto<StateProvinceDto>> GetListAsync();
        Task<StateProvinceDto> GetStateProvinceByAbbreviationAsync(string abbreviation, Guid? countryId = null);
        Task<ListResultDto<StateProvinceDto>> GetStateProvincesByCountryIdAsync(Guid countryId, bool showHidden = false);
        Task<ListResultDto<StateProvinceLookupDto>> GetStateProvinceLookupAsync();
        Task<List<StateProvinceDto>> GetByIdsAsync(Guid[] ids);
    }
}
