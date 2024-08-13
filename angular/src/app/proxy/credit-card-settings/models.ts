import type { CreationAuditedEntityDto, FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateCreditCardSettingDto extends CreationAuditedEntityDto<string> {
  tenantId?: string;
  secretKey: string;
  developerId: string;
  serviceUrl: string;
  americanExpressAccepted: boolean;
  visaAccepted: boolean;
  masterCardAccepted: boolean;
  dinersClubAccepted: boolean;
  discoverAccepted: boolean;
}

export interface CreditCardSettingDto extends FullAuditedEntityDto<string> {
  tenantId?: string;
  secretKey?: string;
  developerId?: string;
  serviceUrl?: string;
  americanExpressAccepted: boolean;
  visaAccepted: boolean;
  masterCardAccepted: boolean;
  dinersClubAccepted: boolean;
  discoverAccepted: boolean;
}
