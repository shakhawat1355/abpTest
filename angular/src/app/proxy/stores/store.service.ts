import type { CreateUpdateStoreDto, StoreDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  apiName = 'Default';
  

  create = (input: CreateUpdateStoreDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StoreDto>({
      method: 'POST',
      url: '/api/app/store',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/store/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StoreDto>({
      method: 'GET',
      url: `/api/app/store/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<StoreDto>>({
      method: 'GET',
      url: '/api/app/store',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getLogoById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: `/api/app/store/${id}/logo`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateStoreDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, StoreDto>({
      method: 'PUT',
      url: `/api/app/store/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
  

  uploadLogoByFileAndId = (file: FormData, id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/store/${id}/upload-logo`,
      body: file,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
