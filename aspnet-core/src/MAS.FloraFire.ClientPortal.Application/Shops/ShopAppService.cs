using System;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using MAS.FloraFire.ClientPortal.Permissions;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace MAS.FloraFire.ClientPortal.Shops
{
    public class ShopAppService : CrudAppService<Shop, ShopDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateShopDto>, IShopAppService 
    {
        public ShopAppService(IRepository<Shop, Guid> repository) : base(repository)
        {
            GetPolicyName = ClientPortalPermissions.Shops.Default;
            GetListPolicyName = ClientPortalPermissions.Shops.Default;
            CreatePolicyName = ClientPortalPermissions.Shops.Create;
            UpdatePolicyName = ClientPortalPermissions.Shops.Edit;
            DeletePolicyName = ClientPortalPermissions.Shops.Delete;
        }

        public async Task<PagedResultDto<ShopDto>> GetFilteredListAsync(GetShopListDto input)
        {
            var query = await Repository.GetQueryableAsync();
            if (!input.Filter.IsNullOrWhiteSpace())
            {
                query = query.Where(c => c.Name.Contains(input.Filter) || 
                    c.ShopCode.Contains(input.Filter) || 
                    c.ZipCode.Contains(input.Filter) ||
                    c.Phone.Contains(input.Filter) ||
                    c.Email.Contains(input.Filter));
            }
            var totalCount = await query.CountAsync(); // get total count before applying pagination
            query = query.OrderByIf<Shop, IQueryable<Shop>>(!input.Sorting.IsNullOrWhiteSpace(), input.Sorting).PageBy(input.SkipCount, input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(query);

            var shopDtos = queryResult.Select(x =>
            {
                var shopDto = ObjectMapper.Map<Shop, ShopDto>(x);
                return shopDto;
            }).ToList();

            return new PagedResultDto<ShopDto>(
                totalCount,
                shopDtos
            );
        }
    }
}
