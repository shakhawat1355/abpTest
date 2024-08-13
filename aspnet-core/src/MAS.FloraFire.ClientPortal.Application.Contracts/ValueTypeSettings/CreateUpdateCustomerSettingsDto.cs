using System;
using System.ComponentModel.DataAnnotations;

namespace MAS.FloraFire.ClientPortal.ValueTypeSettings
{
    public class CreateUpdateCustomerSettingsDto
    {
        [Required]
        public Guid? Status { get; set; }

        [Required]
        public Guid? Type { get; set; }

        [Required]
        public Guid? AcctClass { get; set; }

        [Required]
        public Guid? AcctManager { get; set; }

        [Required]
        public Guid? InvoicePaymentSchedule { get; set; }

        [Required]
        public Guid? Term { get; set; }  
        
        [Required]
        public Guid? ARStatementInvoiceType { get; set; }

        [Required]
        public Guid? PriceSheetCode { get; set; }

        [Required]
        public Guid? ReferredBy { get; set; }
    }
}
