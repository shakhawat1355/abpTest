using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.PhoneDirectories
{
    public class PhoneDirectoryDto : AuditedEntityDto<Guid>, IMultiTenant
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
