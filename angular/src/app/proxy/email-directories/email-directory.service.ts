import type { CreateUpdateEmailDirectoryDto, EmailDirectoryDto, GetEmailListDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EmailDirectoryService {
  apiName = 'Default';
  

  create = (input: CreateUpdateEmailDirectoryDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmailDirectoryDto>({
      method: 'POST',
      url: '/api/app/email-directory',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/email-directory/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmailDirectoryDto>({
      method: 'GET',
      url: `/api/app/email-directory/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getFilteredList = (input: GetEmailListDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<EmailDirectoryDto>>({
      method: 'GET',
      url: '/api/app/email-directory/filtered-list',
      params: { entityId: input.entityId, entityName: input.entityName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<EmailDirectoryDto>>({
      method: 'GET',
      url: '/api/app/email-directory',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateEmailDirectoryDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmailDirectoryDto>({
      method: 'PUT',
      url: `/api/app/email-directory/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
