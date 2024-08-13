import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface CreateUpdateStoreWorkHourDto extends AuditedEntityDto<string> {
  day: any;
  startTime?: string;
  endTime?: string;
  isClose: boolean;
  storeId?: string;
  tenantId?: string;
}

export interface StoreWorkHourDto extends AuditedEntityDto<string> {
  day: any;
  dayName: any;
  startTime?: string;
  endTime?: string;
  isClose: boolean;
  storeId?: string;
  tenantId?: string;
}

export interface StoreWorkHourLookupDto extends EntityDto<string> {
  day: any;
  dayName?: string;
  startTime?: string;
  endTime?: string;
  isClose: boolean;
  storeId?: string;
  tenantId?: string;
}
