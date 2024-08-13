import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface StateProvinceDto extends AuditedEntityDto<string> {
  countryId?: string;
  country?: string;
  name?: string;
  abbreviation?: string;
  displayOrder: number;
}

export interface StateProvinceLookupDto extends EntityDto<string> {
  name?: string;
  countryId?: string;
}
