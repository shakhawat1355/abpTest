using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.EmailDirectories
{
    public interface IEmailDirectoryAppService : ICrudAppService<EmailDirectoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmailDirectoryDto>
    {
        Task<PagedResultDto<EmailDirectoryDto>> GetFilteredListAsync(GetEmailListDto input);
    }
}
