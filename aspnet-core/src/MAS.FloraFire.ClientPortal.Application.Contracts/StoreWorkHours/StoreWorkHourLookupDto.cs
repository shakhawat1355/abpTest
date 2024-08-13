﻿using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.StoreWorkHours
{
    public class StoreWorkHourLookupDto : EntityDto<Guid>
    {
        public DayOfWeek Day { get; set; }
        public string DayName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsClose { get; set; }
        public Guid StoreId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
