using MAS.FloraFire.ClientPortal.Permissions;
using MAS.FloraFire.ClientPortal.StoreWorkHours;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.Stores
{
    [Authorize(ClientPortalPermissions.Stores.Default)]
    public class StoreAppService : CrudAppService<Store, StoreDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStoreDto>, IStoreAppService
    {
        private readonly IRepository<StoreWorkHour> _storeWorkHourRepository;

        public StoreAppService(
            IRepository<Store, Guid> repository,
            IRepository<StoreWorkHour> storeWorkHourRepository) : base(repository)
        {
            _storeWorkHourRepository = storeWorkHourRepository;

            GetPolicyName = ClientPortalPermissions.Stores.Default;
            GetListPolicyName = ClientPortalPermissions.Stores.Default;
            CreatePolicyName = ClientPortalPermissions.Stores.Create;
            UpdatePolicyName = ClientPortalPermissions.Stores.Edit;
            DeletePolicyName = ClientPortalPermissions.Stores.Delete;
        }

        #region Utilities

        private async Task<IList<StoreWorkHourLookupDto>> GetStoreWorkHourLookupAsync(Guid storeId)
        {
            var queryable = (await _storeWorkHourRepository.GetQueryableAsync()).Where(x => x.StoreId == storeId);

            var queryResult = await AsyncExecuter.ToListAsync(queryable);

            if (queryResult.Count() == 0)
            {
                queryResult = new List<StoreWorkHour>
                {
                    new StoreWorkHour { Day = DayOfWeek.Sunday},
                    new StoreWorkHour { Day = DayOfWeek.Monday },
                    new StoreWorkHour { Day = DayOfWeek.Tuesday },
                    new StoreWorkHour { Day = DayOfWeek.Wednesday },
                    new StoreWorkHour { Day = DayOfWeek.Thursday },
                    new StoreWorkHour { Day = DayOfWeek.Friday },
                    new StoreWorkHour { Day = DayOfWeek.Saturday },
                };
            }

            return new List<StoreWorkHourLookupDto>(queryResult.Select(x =>
            {
                var storeWorkHourDto = ObjectMapper.Map<StoreWorkHour, StoreWorkHourLookupDto>(x);
                storeWorkHourDto.DayName = Enum.GetName(typeof(DayOfWeek), x.Day) ?? "";
                return storeWorkHourDto;
            }).ToList());
        }
        #endregion

        public override async Task<StoreDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var query = await Repository.GetQueryableAsync();

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query.Where(x => x.Id == id));
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Store), id);
            }

            var storeDto = ObjectMapper.Map<Store, StoreDto>(queryResult);

            storeDto.StoreWorkHours = await GetStoreWorkHourLookupAsync(id);

            return storeDto;
        }

        public override async Task<PagedResultDto<StoreDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = queryable
                .OrderByDescending(x => x.CreationTime)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var storeDtos = queryResult.Select(x =>
            {
                var StoreDto = ObjectMapper.Map<Store, StoreDto>(x);
                return StoreDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<StoreDto>(
                totalCount,
                storeDtos
            );
        }

        public async override Task<StoreDto> CreateAsync(CreateUpdateStoreDto input)
        {
            return await base.CreateAsync(input);
        }

        public async override Task<StoreDto> UpdateAsync(Guid id, CreateUpdateStoreDto input)
        {
            var storeDto = await base.UpdateAsync(id, input);

            if (input.StoreWorkHours.Count > 0)
            {
                foreach (var item in input.StoreWorkHours)
                {
                    if (item != null)
                    {
                        var workHour = ObjectMapper.Map<CreateUpdateStoreWorkHourDto, StoreWorkHour>(item);
                        workHour.StoreId = id;

                        var existingWorkHour = await _storeWorkHourRepository.FirstOrDefaultAsync(x => x.StoreId == id && x.Day == workHour.Day);
                        if (existingWorkHour != null)
                        {
                            existingWorkHour.StartTime = workHour.StartTime;
                            existingWorkHour.EndTime = workHour.EndTime;
                            existingWorkHour.IsClose = workHour.IsClose;
                            await _storeWorkHourRepository.UpdateAsync(existingWorkHour);
                        }
                        else
                            await _storeWorkHourRepository.InsertAsync(workHour);
                    }
                }
            }

            return storeDto;
        }

        public async Task UploadLogo(IRemoteStreamContent file, Guid id)
        {
            var query = await Repository.GetQueryableAsync();
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query.Where(x => x.Id == id));

            if (queryResult == null)
                throw new EntityNotFoundException(typeof(Store), id);

            using (var memoryStream = new MemoryStream())
            {
                await file.GetStream().CopyToAsync(memoryStream);
                queryResult.Logo = memoryStream.ToArray();
                await Repository.UpdateAsync(queryResult);
            }
        }

        public async Task<IRemoteStreamContent> GetLogo(Guid id)
        {
            var query = await Repository.GetQueryableAsync();
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query.Where(x => x.Id == id));

            if (queryResult == null)
                throw new EntityNotFoundException(typeof(Store), id);

            if (queryResult.Logo != null && queryResult.Logo.Length > 0)
            {
                var stream = new MemoryStream(queryResult.Logo);
                return new RemoteStreamContent(stream, "image/png");
            }
            return new RemoteStreamContent(new MemoryStream(), "application/octet-stream");
        }
    }
}