import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateEmailDirectoryDto {
  tenantId?: string;
  entityId?: string;
  email: string;
  isPrimary: boolean;
  optOutForMarketing: boolean;
  optForDirectMarketing: boolean;
  entityName?: string;
}

export interface EmailDirectoryDto extends AuditedEntityDto<string> {
  tenantId?: string;
  entityId?: string;
  email?: string;
  isPrimary: boolean;
  optOutForMarketing: boolean;
  optForDirectMarketing: boolean;
  entityName?: string;
}

export interface GetEmailListDto extends PagedAndSortedResultRequestDto {
  entityId?: string;
  entityName?: string;
}
