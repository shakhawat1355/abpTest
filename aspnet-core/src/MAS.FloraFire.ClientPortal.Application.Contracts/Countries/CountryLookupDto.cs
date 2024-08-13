using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.Countries
{
    public class CountryLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}