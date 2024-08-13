using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.CustomerComments
{
    public interface ICustomerCommentAppService : ICrudAppService<CustomerCommentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCustomerCommentDto>
    {
    }
}
