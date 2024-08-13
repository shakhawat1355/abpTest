using MAS.FloraFire.ClientPortal.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MAS.FloraFire.ClientPortal.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ClientPortalEntityFrameworkCoreModule),
    typeof(ClientPortalApplicationContractsModule)
    )]
public class ClientPortalDbMigratorModule : AbpModule
{
}
