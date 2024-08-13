import type { CreateUpdateValueTypeDto, ValueTypeDto, ValueTypeLookupDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValueTypeService {
  apiName = 'Default';
  

  create = (input: CreateUpdateValueTypeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueTypeDto>({
      method: 'POST',
      url: '/api/app/value-type',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/value-type/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueTypeDto>({
      method: 'GET',
      url: `/api/app/value-type/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ValueTypeDto>>({
      method: 'GET',
      url: '/api/app/value-type',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getValueTypeLookup = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<ValueTypeLookupDto>>({
      method: 'GET',
      url: '/api/app/value-type/value-type-lookup',
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateValueTypeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueTypeDto>({
      method: 'PUT',
      url: `/api/app/value-type/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
