using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.CreditCardSettings;

public class CreditCardSettingDto : FullAuditedEntityDto<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public string? SecretKey { get; set; }
    public string? DeveloperId { get; set; }
    public string? ServiceUrl { get; set; }
    public bool AmericanExpressAccepted { get; set; }
    public bool VisaAccepted { get; set; }
    public bool MasterCardAccepted { get; set; }
    public bool DinersClubAccepted { get; set; }
    public bool DiscoverAccepted { get; set; }
}
