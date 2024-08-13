using System.Threading.Tasks;

namespace MAS.FloraFire.ClientPortal.Data;

public interface IClientPortalDbSchemaMigrator
{
    Task MigrateAsync();

    Task CreateTenantDatabaseAsync(string tenantName);
}
