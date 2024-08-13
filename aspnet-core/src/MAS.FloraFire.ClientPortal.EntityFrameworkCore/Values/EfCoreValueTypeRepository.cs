using MAS.FloraFire.ClientPortal.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class EfCoreValueTypeRepository : EfCoreRepository<ClientPortalDbContext, ValueType, Guid>,
        IValueTypeRepository
    {
        public EfCoreValueTypeRepository(
            IDbContextProvider<ClientPortalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<ValueType> FindByNameAsync(string name)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Set<ValueType>()
                .Where(p => p.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}