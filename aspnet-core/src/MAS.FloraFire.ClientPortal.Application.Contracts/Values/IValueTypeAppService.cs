
using MAS.FloraFire.ClientPortal.Values;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.Values
{
    public interface IValueTypeAppService : ICrudAppService<ValueTypeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateValueTypeDto>
    {
        Task<ListResultDto<ValueTypeLookupDto>> GetValueTypeLookupAsync();
    }
}
