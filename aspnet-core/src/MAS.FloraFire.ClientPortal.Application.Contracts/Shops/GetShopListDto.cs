using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.Shops
{
    public class GetShopListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
