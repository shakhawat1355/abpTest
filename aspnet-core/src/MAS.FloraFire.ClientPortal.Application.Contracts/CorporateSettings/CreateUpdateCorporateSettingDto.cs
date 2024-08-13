using System;

namespace MAS.FloraFire.ClientPortal.CorporateSettings;

public class CreateUpdateCorporateSettingDto
{
    public Guid? TenantId { get; set; }
    public int WireOutOrderHoldTime { get; set; }
    public bool PrintRawCommMessage { get; set; }
    public int GeocodingPreferenceType { get; set; }
    public int UpdateQuantityCommittedDays { get; set; }
    public int PasswordResetDays { get; set; }
    public int ReturnWindowDays { get; set; }
    public bool AllowCod { get; set; }
    public bool AllowCashOrderEdits { get; set; }
    public long StartingCustomerId { get; set; }
    public long StartingOrderId { get; set; }
    public int PrintNoteCardType { get; set; }
    public decimal ReturnedCheckFee { get; set; }
    public int CreditStatusNotAllowedToCharge { get; set; }
    public int FulfillingStoreId { get; set; }
    public int InventoryTrackingType { get; set; }
    public bool ApplyCreditCardSetupToAllStores { get; set; }
    public decimal RelayFee { get; set; }
    public decimal OverseasRelayFee { get; set; }
    public decimal WireOutDeliveryFee { get; set; }
    public bool TaxOnDelivery { get; set; }
    public bool TaxOnRelay { get; set; }
    public decimal SalesTaxPercentage { get; set; }
    public bool FuneralRequired { get; set; }
    public bool HospitalRequired { get; set; }
    public bool PrintFuneralReviewCopy { get; set; }
    public bool PrintHospitalReviewCopy { get; set; }
    public int CustomerAccountInfoUpdateType { get; set; }
}