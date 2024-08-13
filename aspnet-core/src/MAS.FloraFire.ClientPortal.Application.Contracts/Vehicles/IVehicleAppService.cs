using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MAS.FloraFire.ClientPortal.Vehicles
{
    public interface IVehicleAppService : ICrudAppService<VehicleDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateVehicleDto>
    {
    }
}
