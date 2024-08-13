import { mapEnumToOptions } from '@abp/ng.core';

export enum NumberType {
  Work = 0,
  Home = 1,
  Mobile = 2,
  Other = 3,
}

export const numberTypeOptions = mapEnumToOptions(NumberType);
