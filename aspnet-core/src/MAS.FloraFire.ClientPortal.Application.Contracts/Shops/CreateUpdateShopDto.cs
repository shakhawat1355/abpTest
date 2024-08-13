using System;
using System.ComponentModel.DataAnnotations;

namespace MAS.FloraFire.ClientPortal.Shops
{
    public class CreateUpdateShopDto
    {
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string ShopCode { get; set; }
        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; }
        [StringLength(20)]
        public string? Phone { get; set; }
        [StringLength(500)]
        public string? Email { get; set; }
        public bool? IsFFC { get; set; }
        public int? OpenSunday { get; set; }
        public int? OrderSent { get; set; }
        public int? OrderReceived { get; set; }
        public int? OrderRejected { get; set; }
        [Required]
        public WireService? WireServiceId { get; set; }
        public bool? IsPreferred { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBlocked { get; set; }
        public Guid? TenantId { get; set; }
    }
}
