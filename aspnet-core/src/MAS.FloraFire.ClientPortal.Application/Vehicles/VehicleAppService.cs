using MAS.FloraFire.ClientPortal.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.Vehicles
{
    public class VehicleAppService : CrudAppService<Vehicle, VehicleDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateVehicleDto>, IVehicleAppService
    {
        public VehicleAppService(IRepository<Vehicle, Guid> repository) : base(repository) 
        {
            GetPolicyName = ClientPortalPermissions.Vehicles.Default;
            GetListPolicyName = ClientPortalPermissions.Vehicles.Default;
            CreatePolicyName = ClientPortalPermissions.Vehicles.Create;
            UpdatePolicyName = ClientPortalPermissions.Vehicles.Edit;
            DeletePolicyName = ClientPortalPermissions.Vehicles.Delete;
        }
    }
}
