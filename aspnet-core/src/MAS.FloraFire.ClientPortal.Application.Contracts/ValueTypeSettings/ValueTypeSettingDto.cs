using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.ValueTypeSettings;

public class ValueTypeSettingDto : AuditedEntityDto<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }

    public CustomerSettingsDto CustomerSettings { get; set; } = new CustomerSettingsDto();
}