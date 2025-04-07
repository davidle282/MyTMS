using MyTMS.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Entities
{
    public partial class Booking: BaseEntity
    {
        public long CarrierId { get; set; }
        public long FreightPayerId { get; set; }
        public BookingTypeEnum BookingType { get; set; }
        public BookingStatusEnum BookingStatus { get; set; }
        public string? OrderRef { get; set; }
        public string? DispatchMemo { get; set; }
        
        public decimal? Weight { get; set; }
        public decimal? Cubic {  get; set; }
        public decimal? WeightActual { get; set; }
        public decimal? CubicActual { get; set; }
        public decimal? Cost { get; set; }
        public decimal? CartageCharge { get; set; }
        public decimal? SurchargeCharge { get; set; }
        public decimal? TotalCharge { get; set; }
        public long? CurrentVehicleId { get; set; }
        public long? LastVehicleId { get; set; }
        
        public DateTimeOffset? ContainerDemurrageDate { get; set; }
        public DateTimeOffset? ContainerDetentionDate { get; set; }
        public DateTimeOffset? ContainerDischargedDate { get; set; }
  
        public virtual Vehicle? CurrentVehicle { get; set; } = new Vehicle();
        public virtual Vehicle? LastVehicle { get; set; } = new Vehicle();
        public virtual Organization? Carrier { get; set; } =  new Organization();
        public virtual Organization? FreightPayer { get; set; } = new Organization();
        public virtual User? CreatedByUser { get; set; } = new User();

        public ContainerJobTypeEnum? ContainerJobType { get; set; }
        public ContainerPortCodeEnum? ContainerPortCode { get; set; }
        public string? ContainerNumber { get; set; }
        public string? ContainerVesselName { get; set; }
        public string? ContainerVoyageNo { get; set; }
        public string? ContainerReleaseNo { get; set; }
        public string? ContainerPinNo { get; set; }
        public string? ContainerOwner { get; set; }



    }
}
