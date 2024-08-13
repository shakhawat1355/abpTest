import type { CorporateSettingDto, CreateUpdateCorporateSettingDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CorporateSettingService {
  apiName = 'Default';
  

  getCorporateSetting = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CorporateSettingDto>({
      method: 'GET',
      url: '/api/app/corporate-setting/corporate-setting',
    },
    { apiName: this.apiName,...config });
  

  saveCorporateSetting = (input: CreateUpdateCorporateSettingDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/corporate-setting/save-corporate-setting',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
