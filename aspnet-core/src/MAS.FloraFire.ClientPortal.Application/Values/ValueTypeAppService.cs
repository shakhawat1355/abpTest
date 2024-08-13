using MAS.FloraFire.ClientPortal.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class ValueTypeAppService : CrudAppService<ValueType, ValueTypeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateValueTypeDto>, IValueTypeAppService
    { 
        public ValueTypeAppService(IRepository<ValueType, Guid> repository) : base(repository)
        { 
            GetPolicyName = ClientPortalPermissions.ValueTypes.Default;
            GetListPolicyName = ClientPortalPermissions.ValueTypes.Default;
            CreatePolicyName = ClientPortalPermissions.ValueTypes.Create;
            UpdatePolicyName = ClientPortalPermissions.ValueTypes.Edit;
            DeletePolicyName = ClientPortalPermissions.ValueTypes.Delete;
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"ValueType.{nameof(ValueType.Name)}";
            }

            if (sorting.Contains("valueTypeName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "valueTypeName",
                    "valueType.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"Value.{sorting}";
        }


        public override async Task<ValueTypeDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            // Perform the LINQ query
            var query = from vt in queryable
                        join valueType in queryable on vt.ParentId equals valueType.Id into g
                        from valueType in g.DefaultIfEmpty() 
                        where vt.Id == id
                        select new { vt, valueType };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(ValueType), id);
            }

            var valuetypeDto = ObjectMapper.Map<ValueType, ValueTypeDto>(queryResult.vt);
            if(queryResult.valueType != null)
            {
                valuetypeDto.ParentValueType = queryResult?.valueType?.Name;
            }
            return valuetypeDto;
        }

        public override async Task<PagedResultDto<ValueTypeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            // Asynchronously get the queryable collections
            var queryable = await Repository.GetQueryableAsync(); 

            // Perform the LINQ query
            var query = from vt in queryable
                        join valueType in queryable on vt.ParentId equals valueType.Id into g
                        from valueType in g.DefaultIfEmpty() 
                        select new { vt, valueType };

            query = query.OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var valueTypeDtos = queryResult.Select(x =>
            {
                var valueTypeDto = ObjectMapper.Map<ValueType, ValueTypeDto>(x.vt);
                valueTypeDto.ParentValueType = x.valueType?.Name;
                return valueTypeDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();
            return new PagedResultDto<ValueTypeDto>(
                totalCount,
                valueTypeDtos
            );
        }

        public async Task<ListResultDto<ValueTypeLookupDto>> GetValueTypeLookupAsync()
        {
            var valueType = await Repository.GetListAsync();

            return new ListResultDto<ValueTypeLookupDto>(
                ObjectMapper.Map<List<ValueType>, List<ValueTypeLookupDto>>(valueType)
            );
        }

        public override async Task DeleteAsync(Guid id)
        {
            var valueType = await Repository.GetAsync(id);
            if (valueType != null)
            {
                valueType.IsDeleted = true;
                await Repository.UpdateAsync(valueType);
            }
        }

    }
}
