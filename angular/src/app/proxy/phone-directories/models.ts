import type { NumberType } from './number-type.enum';
import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdatePhoneDirectoryDto {
  tenantId?: string;
  entityId?: string;
  phoneNumber: string;
  numberType: NumberType;
  isAcceptTextMessage: boolean;
  isPrimary: boolean;
  entityName?: string;
}

export interface GetPhoneListDto extends PagedAndSortedResultRequestDto {
  entityId?: string;
  entityName?: string;
}

export interface PhoneDirectoryDto extends AuditedEntityDto<string> {
  tenantId?: string;
  entityId?: string;
  phoneNumber?: string;
  numberType: NumberType;
  isAcceptTextMessage: boolean;
  isPrimary: boolean;
  entityName?: string;
}
