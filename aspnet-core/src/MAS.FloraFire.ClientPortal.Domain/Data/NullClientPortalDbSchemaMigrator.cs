using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MAS.FloraFire.ClientPortal.Data;

/* This is used if database provider does't define
 * IClientPortalDbSchemaMigrator implementation.
 */
public class NullClientPortalDbSchemaMigrator : IClientPortalDbSchemaMigrator, ITransientDependency
{
    public Task CreateTenantDatabaseAsync(string tenantName)
    {
        return Task.CompletedTask;
    }

    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
