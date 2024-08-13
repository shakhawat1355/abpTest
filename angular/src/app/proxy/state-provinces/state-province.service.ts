import type { StateProvinceDto, StateProvinceLookupDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StateProvinceService {
  apiName = 'Default';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StateProvinceDto>({
      method: 'GET',
      url: `/api/app/state-province/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getByIds = (ids: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, StateProvinceDto[]>({
      method: 'GET',
      url: '/api/app/state-province/by-ids',
      params: { ids },
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<StateProvinceDto>>({
      method: 'GET',
      url: '/api/app/state-province',
    },
    { apiName: this.apiName,...config });
  

  getStateProvinceByAbbreviation = (abbreviation: string, countryId?: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StateProvinceDto>({
      method: 'GET',
      url: `/api/app/state-province/state-province-by-abbreviation/${countryId}`,
      params: { abbreviation },
    },
    { apiName: this.apiName,...config });
  

  getStateProvinceLookup = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<StateProvinceLookupDto>>({
      method: 'GET',
      url: '/api/app/state-province/state-province-lookup',
    },
    { apiName: this.apiName,...config });
  

  getStateProvincesByCountryId = (countryId: string, showHidden?: boolean, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<StateProvinceDto>>({
      method: 'GET',
      url: `/api/app/state-province/state-provinces-by-country-id/${countryId}`,
      params: { showHidden },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
