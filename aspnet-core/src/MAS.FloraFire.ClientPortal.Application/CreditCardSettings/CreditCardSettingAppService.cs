using System;
using System.Threading.Tasks;
using MAS.FloraFire.ClientPortal.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Security.Encryption;
using Volo.Abp.SettingManagement;

namespace MAS.FloraFire.ClientPortal.CreditCardSettings;

public class CreditCardSettingAppService : ClientPortalAppService, ICreditCardSettingAppService
{
    private readonly ISettingManager _settingManager;
    private readonly IStringEncryptionService _stringEncryptionService;

    public CreditCardSettingAppService(
        ISettingManager settingManager,
        IStringEncryptionService stringEncryptionService
    )
    {
        _settingManager = settingManager;
        _stringEncryptionService = stringEncryptionService;
    }

    [Authorize(ClientPortalPermissions.CreditCardSettings.Default)]
    public async Task<CreditCardSettingDto> GetCreditCardSettingAsync()
    {
        var settings = await _settingManager.GetAllForCurrentTenantAsync();
        var creditCardSettings = new CreditCardSettingDto();
        var creditCardSettingDtoType = typeof(CreditCardSettingDto);
        var creditCardSettingType = typeof(Settings.CreditCardSettings);

        foreach (var property in creditCardSettingDtoType.GetProperties())
        {
            var propertyName = property.Name;
            var settingName =
                creditCardSettingType.GetField(propertyName)?.GetValue(null) as string;
            var setting = settings.Find(e => e.Name == settingName);

            if (setting == null)
                continue;

            if (propertyName == nameof(CreditCardSettingDto.SecretKey))
                setting.Value = _stringEncryptionService.Decrypt(setting.Value);

            var convertedValue = Convert.ChangeType(setting.Value, property.PropertyType);
            property.SetValue(creditCardSettings, convertedValue);
        }
        return creditCardSettings;
    }

    [Authorize(ClientPortalPermissions.CreditCardSettings.Update)]
    public async Task SaveCreditCardSettingAsync(CreateUpdateCreditCardSettingDto input)
    {
        var creditCardSettingDtoType = typeof(CreateUpdateCreditCardSettingDto);
        var creditCardSettingType = typeof(Settings.CreditCardSettings);

        foreach (var property in creditCardSettingDtoType.GetProperties())
        {
            var propertyName = property.Name;

            if (creditCardSettingType.GetField(propertyName)?.GetValue(null) is not string settingName)
                continue;

            var propertyValue = property.GetValue(input)?.ToString();

            if (propertyName == nameof(CreditCardSettingDto.SecretKey))
                propertyValue = _stringEncryptionService.Encrypt(propertyValue);

            await _settingManager.SetForCurrentTenantAsync(settingName, propertyValue);
        }
    }
}
