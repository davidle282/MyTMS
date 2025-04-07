using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Entities
{
    public partial class Vehicle: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string FleetNumber { get; set; } = string.Empty;
        public string? Registration { get; set; } = string.Empty;
        public string? MakeModel { get; set; } = string.Empty;
        public double? Weight { get; set; }
        public long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; } = new Organization();
        public virtual List<Booking>? CurrentVehicleBookings { get; set; } = new List<Booking>();
        public virtual List<Booking>? LastVehicleBookings { get; set; } = new List<Booking>();

    }
}
