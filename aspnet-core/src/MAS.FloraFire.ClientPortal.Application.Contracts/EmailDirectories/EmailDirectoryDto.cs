using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.EmailDirectories
{
    public class EmailDirectoryDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public Guid? EntityId { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
        public bool OptOutForMarketing { get; set; }
        public bool OptForDirectMarketing { get; set; }
        public string? EntityName { get; set; }
    }
}
