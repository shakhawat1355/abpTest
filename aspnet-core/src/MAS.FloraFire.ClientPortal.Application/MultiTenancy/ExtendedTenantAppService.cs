using AutoMapper.Internal.Mappers;
using MAS.FloraFire.ClientPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;

namespace MAS.FloraFire.ClientPortal.MultiTenancy
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(ITenantAppService), typeof(ExtendedTenantAppService))]
    public class ExtendedTenantAppService : TenantAppService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IServiceProvider _serviceProvider;

        public ExtendedTenantAppService(ITenantRepository tenantRepository,
            ITenantManager tenantManager,
            IDataSeeder dataSeeder,
            IDistributedEventBus distributedEventBus,
            ILocalEventBus localEventBus,
            IServiceProvider serviceProvider) : base(tenantRepository, tenantManager, dataSeeder, distributedEventBus, localEventBus)
        {
            _tenantRepository = tenantRepository;
            _tenantManager = tenantManager;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates a new tenant asynchronously.
        /// </summary>
        /// <param name="input">The tenant creation input.</param>
        /// <returns>The newly created tenant.</returns>
        /// <exception cref="AbpAuthorizationException">Thrown if the current user does not have the required permission.</exception>
        [Authorize(TenantManagementPermissions.Tenants.Create)]
        public override async Task<TenantDto> CreateAsync(TenantCreateDto input)
        {
            // Create a new tenant using the tenant manager
            var tenant = await TenantManager.CreateAsync(input.Name);

            // Map extra properties from the input to the tenant
            input.MapExtraPropertiesTo(tenant);

            // Insert the new tenant into the database
            await TenantRepository.InsertAsync(tenant);

            // Save changes if a unit of work is active
            if (CurrentUnitOfWork != null)
            {
                await CurrentUnitOfWork.SaveChangesAsync();
            }

            // Publish an event indicating that a new tenant has been created
            await DistributedEventBus.PublishAsync(
                new TenantCreatedEto
                {
                    Id = tenant.Id,
                    Name = tenant.Name,
                    Properties =
                    {
                { "AdminEmail", input.AdminEmailAddress },
                { "AdminPassword", input.AdminPassword }
                    }
                });

            // Construct a new connection string for the tenant's database
            //var newConnectionString = $"Server=;Database={dbName};Trusted_Connection=True;TrustServerCertificate=True";
            var newConnectionString = _serviceProvider.GetRequiredService<ClientPortalDbMigrationService>().PrepareTenantConnectionString(tenant);

            // Update the default connection string for the tenant
            await base.UpdateDefaultConnectionStringAsync(tenant.Id, newConnectionString);

            // Save changes if a unit of work is active
            if (CurrentUnitOfWork != null)
            {
                await CurrentUnitOfWork.SaveChangesAsync();
            }

            // Change the current tenant context to the newly created tenant
            using (CurrentTenant.Change(tenant.Id, tenant.Name))
            {
                // Migrate the tenant's database schema
                await _serviceProvider.GetRequiredService<ClientPortalDbMigrationService>().MigrateTenantAsync(tenant);

                // Seed the tenant's database with initial data
                await DataSeeder.SeedAsync(
                    new DataSeedContext(tenant.Id)
                       .WithProperty("AdminEmail", input.AdminEmailAddress)
                       .WithProperty("AdminPassword", input.AdminPassword)
                    );
            }

            // Map the tenant to a DTO and return it
            return ObjectMapper.Map<Tenant, TenantDto>(tenant);
        }
    }
}
