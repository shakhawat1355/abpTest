using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class ValueDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public string Name { get; set; }
        public Guid? ValueTypeId { get; set; }
        public string? ValueType { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPreSelect { get; set; }
        public Guid? TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
