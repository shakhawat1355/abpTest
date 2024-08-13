using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.Customers
{
    public interface ICustomerAppService :
        ICrudAppService<
            CustomerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto>
    {
        Task<CustomerDto> GetCustomerDtoValuesAsync();
    }
}