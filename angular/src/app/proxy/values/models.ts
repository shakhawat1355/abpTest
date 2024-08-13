import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface CreateUpdateValueDto extends AuditedEntityDto<string> {
  name: string;
  valueTypeId?: string;
  displayOrder: number;
  isPreSelect: boolean;
  tenantId?: string;
}

export interface CreateUpdateValueTypeDto {
  name: string;
  parentId?: string;
  parentValueType?: string;
  displayOrder: number;
  isActive: boolean;
  tenantId?: string;
}

export interface ValueDto extends AuditedEntityDto<string> {
  name?: string;
  valueTypeId?: string;
  valueType?: string;
  displayOrder: number;
  isPreSelect: boolean;
  tenantId?: string;
  isDeleted: boolean;
}

export interface ValueTypeDto extends AuditedEntityDto<string> {
  name?: string;
  parentId?: string;
  parentValueType?: string;
  displayOrder: number;
  isActive: boolean;
  tenantId?: string;
}

export interface ValueTypeLookupDto extends EntityDto<string> {
  name?: string;
}
