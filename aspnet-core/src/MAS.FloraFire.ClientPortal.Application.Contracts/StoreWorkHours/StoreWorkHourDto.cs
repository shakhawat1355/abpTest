using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.StoreWorkHours
{
    public class StoreWorkHourDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public DayOfWeek Day { get; set; }
        public DayOfWeek DayName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsClose { get; set; }
        public Guid StoreId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
