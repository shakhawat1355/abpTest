using System;

namespace MAS.FloraFire.ClientPortal.ValueTypeSettings;

public class CreateUpdateValueTypeSettingDto
{
    public Guid? TenantId { get; set; }

    public CreateUpdateCustomerSettingsDto CustomerSettings { get; set; } = new CreateUpdateCustomerSettingsDto();
}