using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class Value : AggregateRoot<Guid>, IMultiTenant, ISoftDelete
    {
        public Guid? TenantId { get; set; }
        public required string Name { get; set; }
        public Guid? ValueTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPreSelect { get; set; }
        public bool IsDeleted { get; set; }

    }
}
