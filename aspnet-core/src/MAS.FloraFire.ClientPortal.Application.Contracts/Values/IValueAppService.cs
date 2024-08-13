using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.Values
{
    public interface IValueAppService : ICrudAppService<ValueDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateValueDto>
    {
        Task<List<ValueDto>> GetAllValuesAsync();
        Task<List<ValueDto>> GetValuesByValueTypeIdAsync(Guid? valueTypeId);
    }
}
