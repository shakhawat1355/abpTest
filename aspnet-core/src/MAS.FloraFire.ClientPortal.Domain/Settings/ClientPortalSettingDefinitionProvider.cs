using Volo.Abp.Settings;

namespace MAS.FloraFire.ClientPortal.Settings;

public class ClientPortalSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ClientPortalSettings.MySetting1));
    }
}
