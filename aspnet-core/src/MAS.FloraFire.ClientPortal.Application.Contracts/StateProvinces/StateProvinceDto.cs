using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.StateProvinces
{
    public class StateProvinceDto : AuditedEntityDto<Guid>
    {
        public Guid CountryId { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public int DisplayOrder { get; set; }
    }
}
