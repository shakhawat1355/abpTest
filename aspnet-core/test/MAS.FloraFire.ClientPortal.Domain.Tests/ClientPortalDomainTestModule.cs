using Volo.Abp.Modularity;

namespace MAS.FloraFire.ClientPortal;

[DependsOn(
    typeof(ClientPortalDomainModule),
    typeof(ClientPortalTestBaseModule)
)]
public class ClientPortalDomainTestModule : AbpModule
{

}
