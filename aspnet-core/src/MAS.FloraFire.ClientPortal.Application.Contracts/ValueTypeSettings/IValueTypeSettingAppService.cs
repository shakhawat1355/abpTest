using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.ValueTypeSettings;

public interface IValueTypeSettingAppService : IApplicationService
{
    Task SaveValueTypeSettingAsync(CreateUpdateValueTypeSettingDto input);
    Task<ValueTypeSettingDto> GetValueTypeSettingAsync();
    Task<CustomerSettingsDto> GetCustomerValueTypeSettingAsync();
}