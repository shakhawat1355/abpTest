import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateCustomerSettingsDto {
  status?: string;
  type?: string;
  acctClass?: string;
  acctManager?: string;
  invoicePaymentSchedule?: string;
  term?: string;
  arStatementInvoiceType?: string;
  priceSheetCode?: string;
  referredBy?: string;
}

export interface CreateUpdateValueTypeSettingDto {
  tenantId?: string;
  customerSettings: CreateUpdateCustomerSettingsDto;
}

export interface CustomerSettingsDto {
  status?: string;
  type?: string;
  acctClass?: string;
  acctManager?: string;
  invoicePaymentSchedule?: string;
  term?: string;
  arStatementInvoiceType?: string;
  priceSheetCode?: string;
  referredBy?: string;
}

export interface ValueTypeSettingDto extends AuditedEntityDto<string> {
  tenantId?: string;
  customerSettings: CustomerSettingsDto;
}
