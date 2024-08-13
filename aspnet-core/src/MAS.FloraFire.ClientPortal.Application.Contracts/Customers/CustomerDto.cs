using MAS.FloraFire.ClientPortal.Stores;
using MAS.FloraFire.ClientPortal.Values;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public string TenantName { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public Guid? StateProvinceId { get; set; }

        public string StateProvince { get; set; }

        public Guid? CountryId { get; set; }

        public string Country { get; set; }

        public bool IsWholeSale { get; set; }

        public bool IsOptDirectoryMarketing { get; set; }

        public Guid? StatusValueId { get; set; }

        public string StatusValue { get; set; }

        public Guid? AcctClassValueId { get; set; }

        public string AcctClassValue { get; set; }

        public Guid? AcctManagerValueId { get; set; }

        public string AcctManagerValue { get; set; }

        public string Fax { get; set; }

        public bool TaxExempt { get; set; }

        public decimal Discount { get; set; }

        public Guid? InvoicePaymentSchedulerValueId { get; set; }

        public string InvoicePaymentSchedulerValue { get; set; }

        public Guid? ARStatementInvoiceTypeValueId { get; set; }

        public string ARStatementInvoiceTypeValue { get; set; }

        public Guid? ReferredByValueId { get; set; }

        public string ReferredByValue { get; set; }

        public Guid? TypeId { get; set; }

        public string Type { get; set; }

        public Guid? StoreId { get; set; }

        public string Store { get; set; }

        public decimal DiscountOnWireout { get; set; }

        public Guid? TermValueId { get; set; }

        public string TermValue { get; set; }

        public Guid? PriceSheetCodeValueId { get; set; }

        public string PriceSheetCodeValue { get; set; }

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

        public IList<ValueDto> AvailableStatuses { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailableTypes { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailableAcctClasses { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailableAcctManagers { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailableInvoicePaymentSchedule { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailableTerms { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailableARStatementInvoiceTypes { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailablePriceSheetCodes { get; set; } = new List<ValueDto>();
        public IList<ValueDto> AvailableReferredBy { get; set; } = new List<ValueDto>();
        public IList<StoreLookupDto> AvailableStores { get; set; } = new List<StoreLookupDto>();
    }
}