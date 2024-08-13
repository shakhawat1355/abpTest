using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAS.FloraFire.ClientPortal.PhoneDirectories
{
    public class CreateUpdatePhoneDirectoryDto
    {
        public Guid? TenantId { get; set; }
        public Guid? EntityId { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public NumberType NumberType { get; set; } = NumberType.Other;
        public bool IsAcceptTextMessage { get; set; }
        public bool IsPrimary { get; set; }
        public string? EntityName { get; set; }
    }
}
