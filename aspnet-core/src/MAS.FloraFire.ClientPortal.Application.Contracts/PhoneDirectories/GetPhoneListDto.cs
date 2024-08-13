using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.PhoneDirectories
{
    public class GetPhoneListDto : PagedAndSortedResultRequestDto
    {
        public Guid? EntityId { get; set; }
        public string? EntityName { get; set; }
    }
}