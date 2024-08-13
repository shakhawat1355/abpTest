import type { CountryDto, CountryLookupDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  apiName = 'Default';
  

  fromCountryCodeByCountryCode = (countryCode: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CountryDto>({
      method: 'POST',
      url: '/api/app/country/from-country-code',
      params: { countryCode },
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CountryDto>({
      method: 'GET',
      url: `/api/app/country/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getByIds = (ids: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, CountryDto[]>({
      method: 'GET',
      url: '/api/app/country/by-ids',
      params: { ids },
    },
    { apiName: this.apiName,...config });
  

  getCountryLookup = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<CountryLookupDto>>({
      method: 'GET',
      url: '/api/app/country/country-lookup',
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<CountryDto>>({
      method: 'GET',
      url: '/api/app/country',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
