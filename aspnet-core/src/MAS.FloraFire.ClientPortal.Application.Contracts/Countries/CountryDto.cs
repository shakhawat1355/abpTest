using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.Countries
{
    public class CountryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string TwoLetterIsoCode { get; set; }

        public string ThreeLetterIsoCode { get; set; }

        public int NumericIsoCode { get; set; }

        public int DisplayOrder { get; set; }
    }
}
