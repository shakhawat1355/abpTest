using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Vehicles
{
    public class VehicleDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string LicensePlate { get; set; }
        public string VIN { get; set; }
        public string Model { get; set; }
        public Guid StatusValueId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? MaintenanceDue { get; set; }
    }
}
