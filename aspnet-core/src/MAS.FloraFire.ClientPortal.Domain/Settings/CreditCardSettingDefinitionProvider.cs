using Volo.Abp.Settings;

namespace MAS.FloraFire.ClientPortal.Settings;

public class CreditCardSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        SettingDefinition[] definitions =
        [
            new(CreditCardSettings.SecretKey),
            new(CreditCardSettings.DeveloperId),
            new(CreditCardSettings.ServiceUrl),
            new(CreditCardSettings.AmericanExpressAccepted),
            new(CreditCardSettings.VisaAccepted),
            new(CreditCardSettings.MasterCardAccepted),
            new(CreditCardSettings.DinersClubAccepted),
            new(CreditCardSettings.DiscoverAccepted),
        ];

        context.Add(definitions);
    }
}
