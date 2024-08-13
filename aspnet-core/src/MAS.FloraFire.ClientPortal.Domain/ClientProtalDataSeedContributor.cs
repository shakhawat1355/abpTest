using MAS.FloraFire.ClientPortal.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using ValueType = MAS.FloraFire.ClientPortal.Values.ValueType;

namespace MAS.FloraFire.ClientPortal
{
    public class ClientProtalDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<ValueType, Guid> _valueTypeRepository;
        private readonly IRepository<Value, Guid> _valueRepository;
        public ClientProtalDataSeedContributor(
            IRepository<ValueType, Guid> valuetypeRepository,
            IRepository<Value, Guid> valueRepository)
        {
            _valueTypeRepository = valuetypeRepository;
            _valueRepository = valueRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        { 
            if (await _valueTypeRepository.GetCountAsync() <= 0)
            {
                var status = await _valueTypeRepository.InsertAsync(
                     new ValueType
                     {
                         Name = "Status",
                         DisplayOrder = 0,
                         IsActive = true,  
                     },
                     autoSave: true
                 );

                var dep = await _valueTypeRepository.InsertAsync(
                       new ValueType
                       {
                           Name = "Department",
                           DisplayOrder = 1,
                           IsActive = true, 
                       },
                       autoSave: true
                   );

                await _valueRepository.InsertAsync(
                    new Value
                    {
                        Name = "Active",
                        DisplayOrder = 0,
                        IsPreSelect = true,
                        ValueTypeId = status.Id,
                    },
                    autoSave: true
                ); await _valueRepository.InsertAsync(
                    new Value
                    {
                        Name = "Sales",
                        DisplayOrder = 0,
                        IsPreSelect = true,
                        ValueTypeId = dep.Id,
                    },
                    autoSave: true
                ); await _valueRepository.InsertAsync(
                    new Value
                    {
                        Name = "InActive",
                        DisplayOrder = 0,
                        IsPreSelect = true,
                        ValueTypeId = status.Id,
                    },
                    autoSave: true
                ); await _valueRepository.InsertAsync(
                    new Value
                    {
                        Name = "Manager",
                        DisplayOrder = 0,
                        IsPreSelect = true,
                        ValueTypeId = dep.Id,
                    },
                    autoSave: true
                );

            }
        }
    }
}
