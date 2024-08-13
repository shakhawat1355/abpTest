using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.CorporateSettings;

public interface ICorporateSettingAppService : IApplicationService
{
    Task SaveCorporateSettingAsync(CreateUpdateCorporateSettingDto input);
    Task<CorporateSettingDto> GetCorporateSettingAsync();
}