import type { CreateUpdateStoreWorkHourDto, StoreWorkHourDto, StoreWorkHourLookupDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StoreWorkHourService {
  apiName = 'Default';
  

  create = (input: CreateUpdateStoreWorkHourDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StoreWorkHourDto>({
      method: 'POST',
      url: '/api/app/store-work-hour',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/store-work-hour/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StoreWorkHourDto>({
      method: 'GET',
      url: `/api/app/store-work-hour/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<StoreWorkHourDto>>({
      method: 'GET',
      url: '/api/app/store-work-hour',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getStoreWorkHourLookup = (storeId?: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<StoreWorkHourLookupDto>>({
      method: 'GET',
      url: `/api/app/store-work-hour/store-work-hour-lookup/${storeId}`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateStoreWorkHourDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StoreWorkHourDto>({
      method: 'PUT',
      url: `/api/app/store-work-hour/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
