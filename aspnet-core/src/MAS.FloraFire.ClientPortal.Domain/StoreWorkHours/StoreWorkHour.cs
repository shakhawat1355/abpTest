using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.StoreWorkHours
{
    public class StoreWorkHour : AggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public DayOfWeek Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsClose { get; set; }
        public Guid StoreId { get; set; }
    }
}