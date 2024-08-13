using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.EmailDirectories
{
    public class GetEmailListDto : PagedAndSortedResultRequestDto
    {
        public Guid? EntityId { get; set; }
        public string? EntityName { get; set; }
    }
}