using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Shops
{
    public class Shop : AggregateRoot<Guid>, IMultiTenant, ISoftDelete
    {
        public string Name { get; set; }
        public string ShopCode { get; set; }
        public string ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsFFC { get; set; }
        public int? OpenSunday { get; set; }
        public int? OrderSent { get; set; }
        public int? OrderReceived { get; set; }
        public int? OrderRejected { get; set; }
        public WireService? WireServiceId { get; set; }
        public bool? IsPreferred { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBlocked { get; set; }
        public Guid? TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
