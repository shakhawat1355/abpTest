import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateCustomerCommentDto {
  comment: string;
  customerId?: string;
  commentAsLocationNote: boolean;
  tenantId?: string;
}

export interface CustomerCommentDto extends AuditedEntityDto<string> {
  comment?: string;
  customerId?: string;
  commentAsLocationNote: boolean;
  tenantId?: string;
}
