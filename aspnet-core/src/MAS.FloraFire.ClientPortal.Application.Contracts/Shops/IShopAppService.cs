using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.Shops
{
    public interface IShopAppService : ICrudAppService<ShopDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateShopDto>
    {

    }
}
