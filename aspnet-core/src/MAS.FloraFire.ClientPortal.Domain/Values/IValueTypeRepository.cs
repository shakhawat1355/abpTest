using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.Values
{
    public interface IValueTypeRepository : IRepository<ValueType, Guid>
    {
        Task<ValueType> FindByNameAsync(string name);
    }
}
