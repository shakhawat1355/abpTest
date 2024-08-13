import type { CreateUpdateValueDto, ValueDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValueService {
  apiName = 'Default';
  

  create = (input: CreateUpdateValueDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueDto>({
      method: 'POST',
      url: '/api/app/value',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/value/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueDto>({
      method: 'GET',
      url: `/api/app/value/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAllValues = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueDto[]>({
      method: 'GET',
      url: '/api/app/value/values',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ValueDto>>({
      method: 'GET',
      url: '/api/app/value',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getValuesByValueTypeId = (valueTypeId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueDto[]>({
      method: 'GET',
      url: `/api/app/value/values-by-value-type-id/${valueTypeId}`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateValueDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ValueDto>({
      method: 'PUT',
      url: `/api/app/value/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
