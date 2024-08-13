using System;

namespace MAS.FloraFire.ClientPortal.ValueTypeSettings
{
    public class CustomerSettingsDto
    {
        public Guid? Status { get; set; }
        public Guid? Type { get; set; }
        public Guid? AcctClass { get; set; }
        public Guid? AcctManager { get; set; }
        public Guid? InvoicePaymentSchedule { get; set; }
        public Guid? Term { get; set; }
        public Guid? ARStatementInvoiceType { get; set; }
        public Guid? PriceSheetCode { get; set; }
        public Guid? ReferredBy { get; set; }
    }
}