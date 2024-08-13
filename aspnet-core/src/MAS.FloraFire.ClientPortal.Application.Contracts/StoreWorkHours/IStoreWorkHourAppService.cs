using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.StoreWorkHours
{
    public interface IStoreWorkHourAppService : ICrudAppService<StoreWorkHourDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStoreWorkHourDto>
    {
        Task<ListResultDto<StoreWorkHourLookupDto>> GetStoreWorkHourLookupAsync(Guid? storeId = null);
    }
}