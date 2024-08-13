using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.CustomerComments
{
    public class CustomerCommentDto : AuditedEntityDto<Guid>
    {
        public string Comment { get; set; }
        public Guid? CustomerId { get; set; }
        public bool CommentAsLocationNote { get; set; }
        public Guid? TenantId { get; set; }
    }
}
