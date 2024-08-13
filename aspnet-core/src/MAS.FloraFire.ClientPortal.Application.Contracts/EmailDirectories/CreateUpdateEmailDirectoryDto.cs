using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAS.FloraFire.ClientPortal.EmailDirectories
{
    public class CreateUpdateEmailDirectoryDto
    {
        public Guid? TenantId { get; set; }
        public Guid? EntityId { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool OptOutForMarketing { get; set; }
        public bool OptForDirectMarketing { get; set; }
        public string? EntityName { get; set; }
    }
}
