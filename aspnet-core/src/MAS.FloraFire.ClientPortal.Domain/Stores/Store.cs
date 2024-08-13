using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Stores
{
    public class Store : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid CountryId { get; set; }
        public string Phone { get; set; }
        public Guid? ManagerId { get; set; }
        public byte[]? Logo { get; set; }
        public TimeZone TimeZone { get; set; }
        public string FaxNumber { get; set; }
        public bool IsAddOnMasDirectory { get; set; }
        public bool IsPrimaryStore { get; set; }
        public bool IsActive { get; set; }
        public bool IsBillingAddress { get; set; }
        public decimal SalesTax { get; set; }
        public bool IsTrackInventory { get; set; }
        public int TimeFormateId { get; set; }
        public string DateTimeFormate { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string PinterestUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool AddtoMasDirectoryNetwork { get; set; }
        public string ReceiptFooterNote { get; set; }
    }
}