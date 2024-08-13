using MAS.FloraFire.ClientPortal.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.CustomerComments
{
    public class CustomerCommentAppService : CrudAppService<CustomerComment, CustomerCommentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCustomerCommentDto>, ICustomerCommentAppService
    {
        public CustomerCommentAppService(IRepository<CustomerComment, Guid> repository) : base(repository)
        {
            GetPolicyName = ClientPortalPermissions.CustomerComments.Default;
            GetListPolicyName = ClientPortalPermissions.CustomerComments.Default;
            CreatePolicyName = ClientPortalPermissions.CustomerComments.Create;
            UpdatePolicyName = ClientPortalPermissions.CustomerComments.Edit;
            DeletePolicyName = ClientPortalPermissions.CustomerComments.Delete;
        }
    }
}
