using MAS.FloraFire.ClientPortal.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace MAS.FloraFire.ClientPortal.Settings;

public class ValueTypeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(
                ValueTypeSettings.Customers.Status,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.Status"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.Status")),

            new SettingDefinition(
                ValueTypeSettings.Customers.Type,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.Type"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.Type")),

            new SettingDefinition(
                ValueTypeSettings.Customers.AcctClass,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.AcctClass"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.AcctClass")),

            new SettingDefinition(
                ValueTypeSettings.Customers.AcctManager,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.AcctManager"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.AcctManager")),

            new SettingDefinition(
                ValueTypeSettings.Customers.InvoicePaymentSchedule,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.InvoicePaymentSchedule"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.InvoicePaymentSchedule")),

            new SettingDefinition(
                ValueTypeSettings.Customers.Term,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.Term"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.Term")),         
            
            new SettingDefinition(
                ValueTypeSettings.Customers.ARStatementInvoiceType,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.ARStatementInvoiceType"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.ARStatementInvoiceType")),           
            
            new SettingDefinition(
                ValueTypeSettings.Customers.PriceSheetCode,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.PriceSheetCode"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.PriceSheetCode")),            
            
            new SettingDefinition(
                ValueTypeSettings.Customers.ReferredBy,
                defaultValue: null,
                displayName: L("DisplayName:ClientPortal.ValueTypeSettings.Customers.ReferredBy"),
                description: L("Description:ClientPortal.ValueTypeSettings.Customers.ReferredBy"))
            );
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ClientPortalResource>(name);
    }
}