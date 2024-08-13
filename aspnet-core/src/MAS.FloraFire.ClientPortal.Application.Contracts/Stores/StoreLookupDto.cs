using System;
using Volo.Abp.Application.Dtos;

namespace MAS.FloraFire.ClientPortal.Stores
{
    public class StoreLookupDto : EntityDto<Guid>
    {
        public string StoreCode { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public string StoreFormatted => $"{this.StoreName}--{this.StoreCode}";
    }
}