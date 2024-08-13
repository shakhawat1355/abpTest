using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.PhoneDirectories
{
    public interface IPhoneDirectoryAppService : ICrudAppService<PhoneDirectoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePhoneDirectoryDto>
    {
        Task<PagedResultDto<PhoneDirectoryDto>> GetFilteredListAsync(GetPhoneListDto input);
    }
}
