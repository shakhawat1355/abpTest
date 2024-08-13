using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MAS.FloraFire.ClientPortal;

[Dependency(ReplaceServices = true)]
public class ClientPortalBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ClientPortal";
}
