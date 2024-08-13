using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAS.FloraFire.ClientPortal.CustomerComments
{
    public class CreateUpdateCustomerCommentDto
    {
        [Required]
        public string Comment { get; set; }
        public Guid? CustomerId { get; set; }
        public bool CommentAsLocationNote { get; set; }
        public Guid? TenantId { get; set; }
    }
}
