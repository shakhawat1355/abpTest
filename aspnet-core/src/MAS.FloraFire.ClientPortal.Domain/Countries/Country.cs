using System;
using Volo.Abp.Domain.Entities;

namespace MAS.FloraFire.ClientPortal.Countries;

public partial class Country : AggregateRoot<Guid>
{
    public string Name { get; set; }

    public string TwoLetterIsoCode { get; set; }

    public string ThreeLetterIsoCode { get; set; }

    public int NumericIsoCode { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }
}