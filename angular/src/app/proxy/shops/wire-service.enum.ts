import { mapEnumToOptions } from '@abp/ng.core';

export enum WireService {
  Bloomnet = 1,
  Teleflora = 2,
  FTD = 3,
  MasDirect = 4,
  FSN = 5,
}

export const wireServiceOptions = mapEnumToOptions(WireService);
