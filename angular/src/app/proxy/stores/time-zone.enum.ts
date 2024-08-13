import { mapEnumToOptions } from '@abp/ng.core';

export enum TimeZone {
  EST = 1,
  MST = 2,
  CST = 3,
  PST = 4,
  HST = 5,
  EDT = 6,
  MDT = 7,
  CDT = 8,
  PDT = 9,
}

export const timeZoneOptions = mapEnumToOptions(TimeZone);
