using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.CreditCardSettings;

public interface ICreditCardSettingAppService : IApplicationService
{
    Task SaveCreditCardSettingAsync(CreateUpdateCreditCardSettingDto input);
    Task<CreditCardSettingDto> GetCreditCardSettingAsync();
}
