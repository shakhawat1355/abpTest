using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAS.FloraFire.ClientPortal.Vehicles
{
    public class CreateUpdateVehicleDto
    {
        public Guid? TenantId { get; set; }

        [Required]
        [StringLength(30)]
        public string LicensePlate { get; set; }

        [Required]
        [StringLength (200)]
        public string VIN { get; set; }

        [StringLength (200)]
        public string Model { get; set; }

        [Required]
        public Guid StatusValueId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MaintenanceDue { get; set; }
    }
}
