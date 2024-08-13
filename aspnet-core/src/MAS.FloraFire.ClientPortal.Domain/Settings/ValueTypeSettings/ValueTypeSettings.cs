namespace MAS.FloraFire.ClientPortal.Settings;

public static class ValueTypeSettings
{
    private const string Prefix = "ClientPortal";

    public static class Customers
    {
        public const string Default = Prefix + ".Customers";
        public const string Status = Default + ".Status";
        public const string Type = Default + ".Type";
        public const string AcctClass = Default + ".AcctClass";
        public const string AcctManager = Default + ".AcctManager";
        public const string InvoicePaymentSchedule = Default + ".InvoicePaymentSchedule";
        public const string Term = Default + ".Term";
        public const string ARStatementInvoiceType = Default + ".ARStatementInvoiceType";
        public const string PriceSheetCode = Default + ".PriceSheetCode";
        public const string ReferredBy = Default + ".ReferredBy";
    }
}