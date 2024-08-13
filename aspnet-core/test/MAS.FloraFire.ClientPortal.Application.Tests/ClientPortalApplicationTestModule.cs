using Volo.Abp.Modularity;

namespace MAS.FloraFire.ClientPortal;

[DependsOn(
    typeof(ClientPortalApplicationModule),
    typeof(ClientPortalDomainTestModule)
)]
public class ClientPortalApplicationTestModule : AbpModule
{

}
