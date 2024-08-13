using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.CustomerComments
{
    public class CustomerComment : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string Comment { get; set; }
        public Guid? CustomerId { get; set; }
        public bool CommentAsLocationNote { get; set; }
    }
}
