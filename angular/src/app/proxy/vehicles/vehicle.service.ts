import type { CreateUpdateVehicleDto, VehicleDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class VehicleService {
  apiName = 'Default';
  

  create = (input: CreateUpdateVehicleDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VehicleDto>({
      method: 'POST',
      url: '/api/app/vehicle',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/vehicle/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VehicleDto>({
      method: 'GET',
      url: `/api/app/vehicle/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<VehicleDto>>({
      method: 'GET',
      url: '/api/app/vehicle',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateVehicleDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VehicleDto>({
      method: 'PUT',
      url: `/api/app/vehicle/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
