using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class ValueTypeDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public  string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentValueType { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public Guid? TenantId { get; set; }
    }
}
