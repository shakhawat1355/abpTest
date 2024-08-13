using MAS.FloraFire.ClientPortal.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace MAS.FloraFire.ClientPortal.Settings;

public class CorporateSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(
                CorporateSettings.WireOutOrderHoldTime,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.WireOutOrderHoldTime"),
                description: L("Description:ClientPortal.CorporateSettings.WireOutOrderHoldTime")),
            
            new SettingDefinition(
                CorporateSettings.PrintRawCommMessage,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.PrintRawCommMessage"),
                description: L("Description:ClientPortal.CorporateSettings.PrintRawCommMessage")),
          
            new SettingDefinition(
                CorporateSettings.GeocodingPreferenceType,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.GeocodingPreferenceType"),
                description: L("Description:ClientPortal.CorporateSettings.GeocodingPreferenceType")),
            
            new SettingDefinition(
                CorporateSettings.UpdateQuantityCommittedDays, 
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.UpdateQuantityCommittedDays"),
                description: L("Description:ClientPortal.CorporateSettings.UpdateQuantityCommittedDays")),
            
            new SettingDefinition(
                CorporateSettings.PasswordResetDays, 
                defaultValue: "0", 
                displayName: L("DisplayName:ClientPortal.CorporateSettings.PasswordResetDays"), 
                description: L("Description:ClientPortal.CorporateSettings.PasswordResetDays")),
            
            new SettingDefinition(
                CorporateSettings.ReturnWindowDays, 
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.ReturnWindowDays"),
                description: L("Description:ClientPortal.CorporateSettings.ReturnWindowDays")),
            
            new SettingDefinition(
                CorporateSettings.AllowCod,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.AllowCOD"),
                description: L("Description:ClientPortal.CorporateSettings.AllowCOD")),
            
            new SettingDefinition(
                CorporateSettings.AllowCashOrderEdits,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.AllowCashOrderEdits"),
                description: L("Description:ClientPortal.CorporateSettings.AllowCashOrderEdits")),

            new SettingDefinition(
                CorporateSettings.StartingCustomerId,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.StartingCustomerId"),
                description: L("Description:ClientPortal.CorporateSettings.StartingCustomerId")),
            
            new SettingDefinition(
                CorporateSettings.StartingOrderId,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.StartingOrderId"),
                description: L("Description:ClientPortal.CorporateSettings.StartingOrderId")),
            
            new SettingDefinition(
                CorporateSettings.PrintNoteCardType,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.PrintNoteCardType"),
                description: L("Description:ClientPortal.CorporateSettings.PrintNoteCardType")),
            
            new SettingDefinition(
                CorporateSettings.ReturnedCheckFee,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.ReturnedCheckFeeType"),
                description: L("Description:ClientPortal.CorporateSettings.ReturnedCheckFeeType")),
            
            new SettingDefinition(
                CorporateSettings.CreditStatusNotAllowedToCharge,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.CreditStatusNotAllowedToCharge"),
                description: L("Description:ClientPortal.CorporateSettings.CreditStatusNotAllowedToCharge")),
            
            new SettingDefinition(
                CorporateSettings.FulfillingStoreId,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.FulfillingStoreId"),
                description: L("Description:ClientPortal.CorporateSettings.FulfillingStoreId")),
            
            new SettingDefinition(
                CorporateSettings.InventoryTrackingType,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.InventoryTrackingType"),
                description: L("Description:ClientPortal.CorporateSettings.InventoryTrackingType")),
            
            new SettingDefinition(
                CorporateSettings.ApplyCreditCardSetupToAllStores,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.ApplyCreditCardSetupToAllStores"),
                description: L("Description:ClientPortal.CorporateSettings.ApplyCreditCardSetupToAllStores")),
            
            new SettingDefinition(
                CorporateSettings.RelayFee,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.RelayFee"),
                description: L("Description:ClientPortal.CorporateSettings.RelayFee")),
            
            new SettingDefinition(
                CorporateSettings.OverseasRelayFee,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.OverseasRelayFee"),
                description: L("Description:ClientPortal.CorporateSettings.OverseasRelayFee")),
            
            new SettingDefinition(
                CorporateSettings.WireOutDeliveryFee,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.WireOutDeliveryFee"),
                description: L("Description:ClientPortal.CorporateSettings.WireOutDeliveryFee")),
            
            new SettingDefinition(
                CorporateSettings.TaxOnDelivery,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.TaxOnDelivery"),
                description: L("Description:ClientPortal.CorporateSettings.TaxOnDelivery")),
            
            new SettingDefinition(
                CorporateSettings.TaxOnRelay,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.TaxOnRelay"),
                description: L("Description:ClientPortal.CorporateSettings.TaxOnRelay")),
            
            new SettingDefinition(
                CorporateSettings.SalesTaxPercentage,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.SalesTaxPercentage"),
                description: L("Description:ClientPortal.CorporateSettings.SalesTaxPercentage")),
            
            new SettingDefinition(
                CorporateSettings.FuneralRequired,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.FuneralRequired"),
                description: L("Description:ClientPortal.CorporateSettings.FuneralRequired")),
            
            new SettingDefinition(
                CorporateSettings.HospitalRequired,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.HospitalRequired"),
                description: L("Description:ClientPortal.CorporateSettings.HospitalRequired")),
            
            new SettingDefinition(
                CorporateSettings.PrintFuneralReviewCopy,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.PrintFuneralReviewCopy"),
                description: L("Description:ClientPortal.CorporateSettings.PrintFuneralReviewCopy")),
            
            new SettingDefinition(
                CorporateSettings.PrintHospitalReviewCopy,
                defaultValue: "false",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.PrintHospitalReviewCopy"),
                description: L("Description:ClientPortal.CorporateSettings.PrintHospitalReviewCopy")),
            
            new SettingDefinition(
                CorporateSettings.CustomerAccountInfoUpdateType,
                defaultValue: "0",
                displayName: L("DisplayName:ClientPortal.CorporateSettings.CustomerAccountInfoUpdateType"),
                description: L("Description:ClientPortal.CorporateSettings.CustomerAccountInfoUpdateType"))
        );
    }
    
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ClientPortalResource>(name);
    }
}