using System;
using System.ComponentModel.DataAnnotations;

namespace MAS.FloraFire.ClientPortal.Customers
{
    public class ImportCustomerDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Zip { get; set; }

        [Required]
        public string StateProvince { get; set; }

        [Required]
        public string Country { get; set; }

        public bool IsWholeSale { get; set; }

        public bool IsOptDirectoryMarketing { get; set; }

        [Required]
        public string StatusValue { get; set; }

        [Required]
        public string AcctClassValue { get; set; }

        [StringLength(200)]
        public string AcctManagerValue { get; set; }

        [StringLength(200)]
        public string Fax { get; set; }

        public bool TaxExempt { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }

        [Required]
        public string InvoicePaymentSchedulerValue { get; set; }

        public string ArStatementInvoiceTypeValue { get; set; }

        public string ReferredByValue { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Store { get; set; }

        [Range(0, 100)]
        public int DiscountOnWireout { get; set; }

        [Required]
        public string TermValue { get; set; }

        public string PriceSheetCodeValue { get; set; }

        [StringLength(200)]
        public string CustomerReference { get; set; }

        public string Comment { get; set; }

        public DateTime? CreationTime { get; set; }
    }

}
