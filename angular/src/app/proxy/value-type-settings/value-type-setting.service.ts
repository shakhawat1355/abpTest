import type { CreateUpdateValueTypeSettingDto, CustomerSettingsDto, ValueTypeSettingDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValueTypeSettingService {
  apiName = 'Default';
  

  getCustomerValueTypeSetting = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerSettingsDto>({
      method: 'GET',
      url: '/api/app/value-type-setting/customer-value-type-setting',
    },
    { apiName: this.apiName,...config });
  

  getValueTypeSetting = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueTypeSettingDto>({
      method: 'GET',
      url: '/api/app/value-type-setting/value-type-setting',
    },
    { apiName: this.apiName,...config });
  

  saveValueTypeSetting = (input: CreateUpdateValueTypeSettingDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/value-type-setting/save-value-type-setting',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
