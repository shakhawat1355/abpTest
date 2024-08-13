using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Vehicles
{
    public class Vehicle : AuditedAggregateRoot<Guid>, IMultiTenant
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
