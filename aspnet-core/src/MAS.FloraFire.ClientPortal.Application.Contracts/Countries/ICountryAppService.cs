using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.Countries
{
    public interface ICountryAppService : IApplicationService
    {
        Task<CountryDto> FromCountryCode(string countryCode);
        Task<CountryDto> GetAsync(Guid id);
        Task<ListResultDto<CountryDto>> GetListAsync();
        Task<ListResultDto<CountryLookupDto>> GetCountryLookupAsync();
        Task<List<CountryDto>> GetByIdsAsync(Guid[] ids);
    }
}