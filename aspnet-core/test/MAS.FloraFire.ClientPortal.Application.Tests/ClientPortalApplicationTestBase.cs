using Volo.Abp.Modularity;

namespace MAS.FloraFire.ClientPortal;

public abstract class ClientPortalApplicationTestBase<TStartupModule> : ClientPortalTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
