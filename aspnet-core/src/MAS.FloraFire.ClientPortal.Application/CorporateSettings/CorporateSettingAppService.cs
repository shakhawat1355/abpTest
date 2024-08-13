using System;
using System.Linq;
using System.Threading.Tasks;
using MAS.FloraFire.ClientPortal.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.SettingManagement;

namespace MAS.FloraFire.ClientPortal.CorporateSettings;

[Authorize(ClientPortalPermissions.CorporateSettings.Default)]
public class CorporateSettingAppService : ClientPortalAppService, ICorporateSettingAppService
{
    private readonly ISettingManager _settingManager;

    public CorporateSettingAppService(ISettingManager settingManager)
    {
        _settingManager = settingManager;
    }
    
    [Authorize(ClientPortalPermissions.CorporateSettings.Create)]
    public async Task SaveCorporateSettingAsync(CreateUpdateCorporateSettingDto input)
    {
        var corporateSettingDtoType = typeof(CreateUpdateCorporateSettingDto);
        var corporateSettingsType = typeof(Settings.CorporateSettings);
        
        foreach (var property in corporateSettingDtoType.GetProperties())
        {
            var fieldName = property.Name;
            var settingName = corporateSettingsType.GetField(fieldName)?.GetValue(null) as string;
            if (settingName == null)
            {
                continue;
            }

            var propertyValue = property.GetValue(input)?.ToString();
            await _settingManager.SetForCurrentTenantAsync(settingName, propertyValue);
        }
    }

    public async Task<CorporateSettingDto> GetCorporateSettingAsync()
    {
        var tenantSettings = await _settingManager.GetAllForCurrentTenantAsync();        
        var corporateSettings = new CorporateSettingDto();
        var corporateSettingsType = typeof(CorporateSettingDto);
        var corporateSettingsFieldType = typeof(Settings.CorporateSettings);

        foreach (var property in corporateSettingsType.GetProperties())
        {
            var fieldName = property.Name;
            var settingName = corporateSettingsFieldType.GetField(fieldName)?.GetValue(null) as string;
            var setting = tenantSettings.FirstOrDefault(ts => ts.Name == settingName);
            if (setting == null)
            {
                continue;
            }

            var convertedValue = Convert.ChangeType(setting.Value, property.PropertyType);
            property.SetValue(corporateSettings, convertedValue);
        }

        return corporateSettings;
    }
}