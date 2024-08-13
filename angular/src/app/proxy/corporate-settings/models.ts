import type { AuditedEntityDto } from '@abp/ng.core';

export interface CorporateSettingDto extends AuditedEntityDto<string> {
  tenantId?: string;
  wireOutOrderHoldTime: number;
  printRawCommMessage: boolean;
  geocodingPreferenceType: number;
  updateQuantityCommittedDays: number;
  passwordResetDays: number;
  returnWindowDays: number;
  allowCod: boolean;
  allowCashOrderEdits: boolean;
  startingCustomerId: number;
  startingOrderId: number;
  printNoteCardType: number;
  returnedCheckFee: number;
  creditStatusNotAllowedToCharge: number;
  fulfillingStoreId: number;
  inventoryTrackingType: number;
  applyCreditCardSetupToAllStores: boolean;
  relayFee: number;
  overseasRelayFee: number;
  wireOutDeliveryFee: number;
  taxOnDelivery: boolean;
  taxOnRelay: boolean;
  salesTaxPercentage: number;
  funeralRequired: boolean;
  hospitalRequired: boolean;
  printFuneralReviewCopy: boolean;
  printHospitalReviewCopy: boolean;
  customerAccountInfoUpdateType: number;
}

export interface CreateUpdateCorporateSettingDto {
  tenantId?: string;
  wireOutOrderHoldTime: number;
  printRawCommMessage: boolean;
  geocodingPreferenceType: number;
  updateQuantityCommittedDays: number;
  passwordResetDays: number;
  returnWindowDays: number;
  allowCod: boolean;
  allowCashOrderEdits: boolean;
  startingCustomerId: number;
  startingOrderId: number;
  printNoteCardType: number;
  returnedCheckFee: number;
  creditStatusNotAllowedToCharge: number;
  fulfillingStoreId: number;
  inventoryTrackingType: number;
  applyCreditCardSetupToAllStores: boolean;
  relayFee: number;
  overseasRelayFee: number;
  wireOutDeliveryFee: number;
  taxOnDelivery: boolean;
  taxOnRelay: boolean;
  salesTaxPercentage: number;
  funeralRequired: boolean;
  hospitalRequired: boolean;
  printFuneralReviewCopy: boolean;
  printHospitalReviewCopy: boolean;
  customerAccountInfoUpdateType: number;
}
