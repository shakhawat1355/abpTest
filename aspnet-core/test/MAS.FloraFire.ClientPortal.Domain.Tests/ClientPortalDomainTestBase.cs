using Volo.Abp.Modularity;

namespace MAS.FloraFire.ClientPortal;

/* Inherit from this class for your domain layer tests. */
public abstract class ClientPortalDomainTestBase<TStartupModule> : ClientPortalTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
