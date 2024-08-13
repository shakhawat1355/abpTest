using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class ValueTypeLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
