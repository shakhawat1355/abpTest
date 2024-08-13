using MAS.FloraFire.ClientPortal.StoreWorkHours;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAS.FloraFire.ClientPortal.Stores
{
    public class CreateUpdateStoreDto
    {
        public Guid? TenantId { get; set; }

        [Required]
        [StringLength(50)]
        public string StoreCode { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string StoreName { get; set; } = string.Empty;

        [StringLength(500)]
        public string ContactName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string AddressLine1 { get; set; } = string.Empty;

        [MaxLength(500)]
        public string AddressLine2 { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string City { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        public Guid ProvinceId { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        public Guid? ManagerId { get; set; }

        [Required]
        public TimeZone TimeZone { get; set; }

        [StringLength(50)]
        public string FaxNumber { get; set; } = string.Empty;

        public bool IsAddOnMasDirectory { get; set; }

        public bool IsPrimaryStore { get; set; }

        public bool IsBillingAddress { get; set; }

        public decimal SalesTax { get; set; }

        public bool IsTrackInventory { get; set; }

        public int TimeFormateId { get; set; }

        [MaxLength(10)]
        public string DateTimeFormate { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? FacebookUrl { get; set; }

        [MaxLength(500)]
        public string? TwitterUrl { get; set; }

        [MaxLength(500)]
        public string? PinterestUrl { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool AddtoMasDirectoryNetwork { get; set; }

        public string? ReceiptFooterNote { get; set; }

        public bool IsActive { get; set; }

        public IList<CreateUpdateStoreWorkHourDto> StoreWorkHours { get; set; } = [];
    }
}