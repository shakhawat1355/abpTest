import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface CountryDto extends AuditedEntityDto<string> {
  name?: string;
  twoLetterIsoCode?: string;
  threeLetterIsoCode?: string;
  numericIsoCode: number;
  displayOrder: number;
}

export interface CountryLookupDto extends EntityDto<string> {
  name?: string;
}
