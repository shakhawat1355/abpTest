import type { WireService } from './wire-service.enum';
import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateShopDto {
  name: string;
  shopCode: string;
  zipCode: string;
  phone?: string;
  email?: string;
  isFFC?: boolean;
  openSunday?: number;
  orderSent?: number;
  orderReceived?: number;
  orderRejected?: number;
  wireServiceId?: WireService;
  isPreferred?: boolean;
  isActive?: boolean;
  isBlocked?: boolean;
  tenantId?: string;
}

export interface GetShopListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface ShopDto extends AuditedEntityDto<string> {
  name?: string;
  shopCode?: string;
  zipCode?: string;
  phone?: string;
  email?: string;
  isFFC?: boolean;
  openSunday?: number;
  orderSent?: number;
  orderReceived?: number;
  orderRejected?: number;
  wireServiceId?: WireService;
  isPreferred?: boolean;
  isActive?: boolean;
  isBlocked?: boolean;
  tenantId?: string;
  isDeleted: boolean;
}
