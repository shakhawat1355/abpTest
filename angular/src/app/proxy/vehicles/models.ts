import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateVehicleDto {
  tenantId?: string;
  licensePlate: string;
  vin: string;
  model?: string;
  statusValueId: string;
  expirationDate?: string;
  maintenanceDue?: string;
}

export interface VehicleDto extends AuditedEntityDto<string> {
  tenantId?: string;
  licensePlate?: string;
  vin?: string;
  model?: string;
  statusValueId?: string;
  expirationDate?: string;
  maintenanceDue?: string;
}
