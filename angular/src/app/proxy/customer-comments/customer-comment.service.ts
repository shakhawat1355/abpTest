import type { CreateUpdateCustomerCommentDto, CustomerCommentDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomerCommentService {
  apiName = 'Default';
  

  create = (input: CreateUpdateCustomerCommentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerCommentDto>({
      method: 'POST',
      url: '/api/app/customer-comment',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/customer-comment/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerCommentDto>({
      method: 'GET',
      url: `/api/app/customer-comment/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<CustomerCommentDto>>({
      method: 'GET',
      url: '/api/app/customer-comment',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateCustomerCommentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerCommentDto>({
      method: 'PUT',
      url: `/api/app/customer-comment/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
