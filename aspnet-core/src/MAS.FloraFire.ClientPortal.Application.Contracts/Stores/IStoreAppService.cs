using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace MAS.FloraFire.ClientPortal.Stores
{
    public interface IStoreAppService : ICrudAppService<StoreDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStoreDto>
    {
        Task<IRemoteStreamContent> GetLogo(Guid id);
        Task UploadLogo(IRemoteStreamContent file, Guid id);
    }
}