using System;
using System.ComponentModel.DataAnnotations;
namespace MAS.FloraFire.ClientPortal.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public Guid? TenantId { get; set; }

        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string? Address2 { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Zip { get; set; }

        [Required]
        public Guid StateProvinceId { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        public bool IsWholeSale { get; set; }

        public bool IsOptDirectoryMarketing { get; set; }

        [Required]
        public Guid StatusValueId { get; set; }

        [Required]
        public Guid AcctClassValueId { get; set; }

        public Guid? AcctManagerValueId { get; set; }

        [StringLength(200)]
        public string? Fax { get; set; }

        public bool TaxExempt { get; set; }

        public decimal Discount { get; set; }

        [Required]
        public Guid InvoicePaymentSchedulerValueId { get; set; }

        public Guid? ARStatementInvoiceTypeValueId { get; set; }

        public Guid? ReferredByValueId { get; set; }

        [Required]
        public Guid TypeId { get; set; }

        [Required]
        public Guid StoreId { get; set; }

        public decimal DiscountOnWireout { get; set; }

        [Required]
        public Guid TermValueId { get; set; }

        public Guid? PriceSheetCodeValueId { get; set; }

        [StringLength(200)]
        public string? CustomerReference { get; set; }

        public string? Comment { get; set; }

        public DateTime AccountOpenDateTime { get; set; }

        public DateTime? LastStatementDate { get; set; }

        public DateTime? LastPurchaseDate { get; set; }

        public DateTime? LastPaymentDate { get; set; }

        public decimal YTDPayments { get; set; }

        public decimal LYTDPayments { get; set; }

        public decimal LifetimePayments { get; set; }

        public decimal LifetimeCreditLimit { get; set; }

        public decimal YTDAmount { get; set; }

        public decimal LYTDsalesAmount { get; set; }

        public decimal LifetimeSalesAmount { get; set; }
    }
}
