using MAS.FloraFire.ClientPortal.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.Values
{
    public class ValueAppService : CrudAppService<Value, ValueDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateValueDto>, IValueAppService
    {
        private readonly IRepository<ValueType> _typeRepository;
        public ValueAppService(IRepository<Value, Guid> repository, IRepository<ValueType> typeRepository) : base(repository)
        {
            _typeRepository = typeRepository;

            GetPolicyName = ClientPortalPermissions.Values.Default;
            GetListPolicyName = ClientPortalPermissions.Values.Default;
            CreatePolicyName = ClientPortalPermissions.Values.Create;
            UpdatePolicyName = ClientPortalPermissions.Values.Edit;
            DeletePolicyName = ClientPortalPermissions.Values.Delete;
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"Value.{nameof(Value.Name)}";
            }

            if (sorting.Contains("valueName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "valueName",
                    "value.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"Value.{sorting}";
        }


        public override async Task<ValueDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from Value in queryable
                        join valueType in await _typeRepository.GetQueryableAsync() on Value.ValueTypeId equals valueType.Id
                        where Value.Id == id
                        select new { Value, valueType };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Value), id);
            }

            var valueDto = ObjectMapper.Map<Value, ValueDto>(queryResult.Value);
            valueDto.ValueType = queryResult.valueType.Name;
            return valueDto;
        }


        public override async Task<PagedResultDto<ValueDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from Value in queryable
                        join valueType in await _typeRepository.GetQueryableAsync() on Value.ValueTypeId equals valueType.Id
                        select new { Value, valueType };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var valueDtos = queryResult.Select(x =>
            {
                var valueDto = ObjectMapper.Map<Value, ValueDto>(x.Value);
                valueDto.ValueType = x.valueType.Name;
                return valueDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ValueDto>(
                totalCount,
                valueDtos
            );
        }

        public override async Task DeleteAsync(Guid id)
        {
            var value = await Repository.GetAsync(id);
            if (value != null)
            {
                value.IsDeleted = true;
                await Repository.UpdateAsync(value);
            }
        }

        public async Task<List<ValueDto>> GetAllValuesAsync()
        {
            var values = await Repository.GetListAsync(x => !x.IsDeleted);

            return values.Select(x => ObjectMapper.Map<Value, ValueDto>(x)).ToList();
        }

        public async Task<List<ValueDto>> GetValuesByValueTypeIdAsync(Guid? valueTypeId)
        {
            if (valueTypeId is null)
                return new List<ValueDto> { };

            var values = await Repository.GetListAsync(x => x.ValueTypeId == valueTypeId && !x.IsDeleted);

            return values.Select(x => ObjectMapper.Map<Value, ValueDto>(x)).ToList();
        }
    }
}
