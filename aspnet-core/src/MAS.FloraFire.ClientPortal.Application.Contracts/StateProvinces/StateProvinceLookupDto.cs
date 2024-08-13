using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.StateProvinces
{
    public class StateProvinceLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}