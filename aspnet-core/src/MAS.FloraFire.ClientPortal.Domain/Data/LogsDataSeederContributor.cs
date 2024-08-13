using System;
using System.Threading.Tasks;
using MAS.FloraFire.ClientPortal.Logs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.Data;

public class LogsDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<AuditType, Guid> _auditTypeRepository;

    public LogsDataSeederContributor(IRepository<AuditType, Guid> auditTypeRepository)
    {
        _auditTypeRepository = auditTypeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        AuditType[] auditTypes =
        [
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Store,
                Name = "Store",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Settings,
                Name = "Settings",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Customer,
                Name = "Customer",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Order,
                Name = "Order",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Transaction,
                Name = "Transaction",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Product,
                Name = "Product",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Employee,
                Name = "Employee",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.GiftCard,
                Name = "Gift Card",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Vehicle,
                Name = "Vehicle",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Auth,
                Name = "Auth",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.Discount,
                Name = "Discount",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.UserPermission,
                Name = "User Permission",
                IsActive = true
            },
            new()
            {
                SystemKeyWord = LogTypes.AuditLogType.SystemIntegrity,
                Name = "System Integrity",
                IsActive = true
            }
        ];

        if (await _auditTypeRepository.GetCountAsync() == 0)
            await _auditTypeRepository.InsertManyAsync(auditTypes);
    }
}
