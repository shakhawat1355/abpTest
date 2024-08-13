import type { TimeZone } from './time-zone.enum';
import type { CreateUpdateStoreWorkHourDto, StoreWorkHourLookupDto } from '../store-work-hours/models';
import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface CreateUpdateStoreDto {
  tenantId?: string;
  storeCode: string;
  storeName: string;
  contactName?: string;
  email: string;
  addressLine1: string;
  addressLine2?: string;
  city: string;
  zipCode: string;
  provinceId: string;
  countryId: string;
  phone: string;
  managerId?: string;
  timeZone: TimeZone;
  faxNumber?: string;
  isAddOnMasDirectory: boolean;
  isPrimaryStore: boolean;
  isBillingAddress: boolean;
  salesTax: number;
  isTrackInventory: boolean;
  timeFormateId: number;
  dateTimeFormate?: string;
  facebookUrl?: string;
  twitterUrl?: string;
  pinterestUrl?: string;
  latitude: number;
  longitude: number;
  addtoMasDirectoryNetwork: boolean;
  receiptFooterNote?: string;
  isActive: boolean;
  storeWorkHours: CreateUpdateStoreWorkHourDto[];
}

export interface StoreDto extends AuditedEntityDto<string> {
  tenantId?: string;
  storeCode?: string;
  storeName?: string;
  contactName?: string;
  email?: string;
  addressLine1?: string;
  addressLine2?: string;
  city?: string;
  zipCode?: string;
  provinceId?: string;
  countryId?: string;
  phone?: string;
  managerId?: string;
  timeZone: TimeZone;
  faxNumber?: string;
  isAddOnMasDirectory: boolean;
  isPrimaryStore: boolean;
  isBillingAddress: boolean;
  salesTax: number;
  isTrackInventory: boolean;
  timeFormateId: number;
  dateTimeFormate?: string;
  facebookUrl?: string;
  twitterUrl?: string;
  pinterestUrl?: string;
  latitude: number;
  longitude: number;
  addtoMasDirectoryNetwork: boolean;
  receiptFooterNote?: string;
  isActive: boolean;
  storeWorkHours: StoreWorkHourLookupDto[];
}

export interface StoreLookupDto extends EntityDto<string> {
  storeCode?: string;
  storeName?: string;
  storeFormatted?: string;
}
