using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class CreateUpdateValueDto : AuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty; 
        public Guid? ValueTypeId { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public bool IsPreSelect { get; set; } = false;
        public Guid? TenantId { get; set; }
    }
}
