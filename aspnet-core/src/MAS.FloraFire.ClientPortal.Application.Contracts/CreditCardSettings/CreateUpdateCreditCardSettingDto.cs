using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.CreditCardSettings;

public class CreateUpdateCreditCardSettingDto : CreationAuditedEntityDto<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    [Required]
    [MaxLength(255)]
    public string SecretKey { get; set; } = string.Empty;

    [Required]
    [StringLength(6)]
    public string DeveloperId { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Url)]
    [MaxLength(255)]
    public string ServiceUrl { get; set; } = string.Empty;

    public bool AmericanExpressAccepted { get; set; }
    public bool VisaAccepted { get; set; }
    public bool MasterCardAccepted { get; set; }
    public bool DinersClubAccepted { get; set; }
    public bool DiscoverAccepted { get; set; }
}
