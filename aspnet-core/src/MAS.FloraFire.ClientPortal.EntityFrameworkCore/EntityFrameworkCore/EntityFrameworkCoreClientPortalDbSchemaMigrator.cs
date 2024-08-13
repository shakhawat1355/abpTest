using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MAS.FloraFire.ClientPortal.Data;
using Volo.Abp.DependencyInjection;

namespace MAS.FloraFire.ClientPortal.EntityFrameworkCore;

public class EntityFrameworkCoreClientPortalDbSchemaMigrator
    : IClientPortalDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreClientPortalDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ClientPortalDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ClientPortalDbContext>()
            .Database
            .MigrateAsync();
    }

    /// <summary>
    /// Creates a new tenant database with the given tenant name and database name.
    /// </summary>
    /// <param name="tenantName">The name of the tenant for which the database is being created.</param>
    /// <param name="databaseName">The name of the new database to be created.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown when an error occurs during the database creation process.</exception>
    public async Task CreateTenantDatabaseAsync(string tenantName)
    {
        try
        {
            await _serviceProvider.GetRequiredService<ClientPortalDbContext>().Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            // Handle database creation error
            Console.WriteLine($"Error creating database for tenant {tenantName}: {ex.Message}");
            throw; // Rethrow the exception for handling at a higher level
        }
    }
}
