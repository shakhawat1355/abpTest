using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.PhoneDirectories
{
    public class PhoneDirectory : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public Guid? EntityId { get; set; }
        public string PhoneNumber { get; set; }
        public NumberType NumberType { get; set; }
        public bool IsAcceptTextMessage { get; set; }
        public bool IsPrimary { get; set; }
        public string? EntityName { get; set; }
    }
}
