using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MAS.FloraFire.ClientPortal.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ClientPortalDbContextFactory : IDesignTimeDbContextFactory<ClientPortalDbContext>
{
    public ClientPortalDbContext CreateDbContext(string[] args)
    {
        ClientPortalEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ClientPortalDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ClientPortalDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MAS.FloraFire.ClientPortal.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
