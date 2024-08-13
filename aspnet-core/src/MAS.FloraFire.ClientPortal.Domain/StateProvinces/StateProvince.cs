using System;
using Volo.Abp.Domain.Entities;
namespace MAS.FloraFire.ClientPortal.StateProvinces;

public partial class StateProvince : AggregateRoot<Guid>
{
    public Guid CountryId { get; set; }

    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public bool Published { get; set; }

    public int DisplayOrder { get; set; }
}