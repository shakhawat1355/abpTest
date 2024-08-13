using MAS.FloraFire.ClientPortal.StoreWorkHours;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Stores
{
    public class StoreDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public string StoreCode { get; set; } = string.Empty;

        public string StoreName { get; set; } = string.Empty;

        public string ContactName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string AddressLine1 { get; set; } = string.Empty;

        public string AddressLine2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public Guid ProvinceId { get; set; }

        public Guid CountryId { get; set; }

        public string Phone { get; set; } = string.Empty;

        public Guid? ManagerId { get; set; }

        public TimeZone TimeZone { get; set; }

        public string FaxNumber { get; set; } = string.Empty;

        public bool IsAddOnMasDirectory { get; set; }

        public bool IsPrimaryStore { get; set; }

        public bool IsBillingAddress { get; set; }

        public decimal SalesTax { get; set; }

        public bool IsTrackInventory { get; set; }

        public int TimeFormateId { get; set; }

        public string DateTimeFormate { get; set; } = string.Empty;

        public string FacebookUrl { get; set; } = string.Empty;

        public string TwitterUrl { get; set; } = string.Empty;

        public string PinterestUrl { get; set; } = string.Empty;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool AddtoMasDirectoryNetwork { get; set; }

        public string? ReceiptFooterNote { get; set; }

        public bool IsActive { get; set; }

        public IList<StoreWorkHourLookupDto> StoreWorkHours { get; set; } = new List<StoreWorkHourLookupDto>();
    }
}