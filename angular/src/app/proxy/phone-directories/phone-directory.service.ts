import type { CreateUpdatePhoneDirectoryDto, GetPhoneListDto, PhoneDirectoryDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PhoneDirectoryService {
  apiName = 'Default';
  

  create = (input: CreateUpdatePhoneDirectoryDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PhoneDirectoryDto>({
      method: 'POST',
      url: '/api/app/phone-directory',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/phone-directory/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PhoneDirectoryDto>({
      method: 'GET',
      url: `/api/app/phone-directory/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getFilteredList = (input: GetPhoneListDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<PhoneDirectoryDto>>({
      method: 'GET',
      url: '/api/app/phone-directory/filtered-list',
      params: { entityId: input.entityId, entityName: input.entityName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<PhoneDirectoryDto>>({
      method: 'GET',
      url: '/api/app/phone-directory',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdatePhoneDirectoryDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PhoneDirectoryDto>({
      method: 'PUT',
      url: `/api/app/phone-directory/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
