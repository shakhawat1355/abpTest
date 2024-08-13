using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.EmailDirectories
{
    public class EmailDirectory : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId {  get; set; }
        public Guid? EntityId { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
        public bool OptOutForMarketing { get; set; }
        public bool OptForDirectMarketing { get; set; }
        public string? EntityName { get; set; }
    }
}
