using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.StoreWorkHours
{
    public class StoreWorkHourAppService : CrudAppService<StoreWorkHour, StoreWorkHourDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStoreWorkHourDto>, IStoreWorkHourAppService
    {
        public StoreWorkHourAppService(IRepository<StoreWorkHour, Guid> repository) : base(repository)
        {
        }

        public override async Task<StoreWorkHourDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(queryable.Where(x => x.Id == id));

            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(StoreWorkHour), id);
            }

            var storeWorkHourDto = ObjectMapper.Map<StoreWorkHour, StoreWorkHourDto>(queryResult);
            if (queryResult != null)
            {
                storeWorkHourDto.DayName = (DayOfWeek)storeWorkHourDto.Day;
            }
            return storeWorkHourDto;
        }

        public override async Task<PagedResultDto<StoreWorkHourDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from q in queryable.OrderBy(x => x.Day)
                  .Skip(input.SkipCount)
                  .Take(input.MaxResultCount)
                        select q;

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var storeWorkHourDtos = queryResult.Select(x =>
            {
                var storeWorkHourDto = ObjectMapper.Map<StoreWorkHour, StoreWorkHourDto>(x);
                storeWorkHourDto.DayName = (DayOfWeek)x.Day;
                return storeWorkHourDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();
            return new PagedResultDto<StoreWorkHourDto>(
                totalCount,
                storeWorkHourDtos
            );
        }

        public async Task<ListResultDto<StoreWorkHourLookupDto>> GetStoreWorkHourLookupAsync(Guid? storeId = null)
        {
            var queryable = await Repository.GetQueryableAsync();
            if (storeId != null)
                queryable = queryable.Where(x => x.StoreId == storeId);

            var queryResult = await AsyncExecuter.ToListAsync(queryable);

            return new ListResultDto<StoreWorkHourLookupDto>(
                ObjectMapper.Map<List<StoreWorkHour>, List<StoreWorkHourLookupDto>>(queryResult)
            );
        }
    }
}
