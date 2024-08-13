using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>, IMultiTenant, ISoftDelete
    {
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public Guid StateProvinceId { get; set; }
        public Guid CountryId { get; set; }
        public bool IsWholeSale { get; set; }
        public bool IsOptDirectoryMarketing { get; set; }
        public Guid StatusValueId { get; set; }
        public Guid AcctClassValueId { get; set; }
        public Guid? AcctManagerValueId { get; set; }
        public string Fax { get; set; }
        public bool TaxExempt { get; set; }
        public decimal Discount { get; set; }
        public Guid InvoicePaymentSchedulerValueId { get; set; }
        public Guid? ARStatementInvoiceTypeValueId { get; set; }
        public Guid? ReferredByValueId { get; set; }
        public Guid TypeId { get; set; }
        public Guid StoreId { get; set; }
        public decimal DiscountOnWireout { get; set; }
        public Guid TermValueId { get; set; }
        public Guid? PriceSheetCodeValueId { get; set; }
        public string CustomerReference { get; set; }
        public string Comment { get; set; }
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
        public bool IsDeleted { get; set; }
    }
}
