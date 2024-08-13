import type { CreateUpdateCreditCardSettingDto, CreditCardSettingDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CreditCardSettingService {
  apiName = 'Default';
  

  getCreditCardSetting = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CreditCardSettingDto>({
      method: 'GET',
      url: '/api/app/credit-card-setting/credit-card-setting',
    },
    { apiName: this.apiName,...config });
  

  saveCreditCardSetting = (input: CreateUpdateCreditCardSettingDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/credit-card-setting/save-credit-card-setting',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
