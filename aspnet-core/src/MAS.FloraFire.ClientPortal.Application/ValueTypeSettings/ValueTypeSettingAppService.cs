using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS.FloraFire.ClientPortal.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace MAS.FloraFire.ClientPortal.ValueTypeSettings;

[Authorize(ClientPortalPermissions.ValueTypeSettings.Default)]
public class ValueTypeSettingAppService : ClientPortalAppService, IValueTypeSettingAppService
{
    #region Fields

    private readonly ISettingManager _settingManager;

    #endregion

    #region Ctor

    public ValueTypeSettingAppService(ISettingManager settingManager)
    {
        _settingManager = settingManager;
    }

    #endregion

    #region Utilities

    private async Task SaveValueTypeSettingsFromDtoAsync(Type settingsConstType, object dtoInstance)
    {
        foreach (var property in dtoInstance.GetType().GetProperties())
        {
            var fieldName = property.Name;
            var settingName = settingsConstType.GetField(fieldName)?.GetValue(null) as string;

            if (settingName == null) continue;

            var propertyValue = property.GetValue(dtoInstance)?.ToString();
            await _settingManager.SetForCurrentTenantAsync(settingName, propertyValue);
        }
    }

    private void MapValueTypeSettingsToDto(Type settingsConstType, object dtoInstance, List<SettingValue> tenantSettings)
    {
        foreach (var property in dtoInstance.GetType().GetProperties())
        {
            var fieldName = property.Name;
            var settingName = settingsConstType.GetField(fieldName)?.GetValue(null) as string;
            var setting = tenantSettings.FirstOrDefault(ts => ts.Name == settingName);

            if (setting != null && setting.Value != null)
            {
                var convertedValue = (property.PropertyType == typeof(Guid?))
                                        ? Guid.Parse(setting.Value)
                                        : Convert.ChangeType(setting.Value, property.PropertyType);

                property.SetValue(dtoInstance, convertedValue);
            }
        }
    }

    #endregion

    #region Methods

    [Authorize(ClientPortalPermissions.ValueTypeSettings.Create)]
    public async Task SaveValueTypeSettingAsync(CreateUpdateValueTypeSettingDto input)
    {
        // Save settings for Customers
        await SaveValueTypeSettingsFromDtoAsync(typeof(Settings.ValueTypeSettings.Customers), input.CustomerSettings);
    }

    public async Task<ValueTypeSettingDto> GetValueTypeSettingAsync()
    {
        var tenantSettings = await _settingManager.GetAllForCurrentTenantAsync();
        var valueTypeSettings = new ValueTypeSettingDto();

        // Retrieve and map settings for Customers
        MapValueTypeSettingsToDto(typeof(Settings.ValueTypeSettings.Customers), valueTypeSettings.CustomerSettings, tenantSettings);

        return valueTypeSettings;
    }

    public async Task<CustomerSettingsDto> GetCustomerValueTypeSettingAsync()
    {
        var tenantSettings = await _settingManager.GetAllForCurrentTenantAsync();
        var customerValueTypeDto = new CustomerSettingsDto();

        // Retrieve and map settings for Customers
        MapValueTypeSettingsToDto(typeof(Settings.ValueTypeSettings.Customers), customerValueTypeDto, tenantSettings);

        return customerValueTypeDto;
    }

    #endregion
}