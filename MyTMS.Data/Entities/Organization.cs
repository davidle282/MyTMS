using MyTMS.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Entities
{
    public partial class Organization: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public OrganizationTypeEnum OrganizationType { get; set; }
        public string? Description { get; set; }
        public virtual List<Vehicle>? Vehicles { get; set; } = new List<Vehicle>();
        public virtual List<Place>? Places { get; set; } = new List<Place>();

    }
}
