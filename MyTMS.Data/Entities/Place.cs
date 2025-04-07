using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Entities
{
    public partial class Place: BaseEntity
    {
        public string PlaceName { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; } = new Organization();

    }
}
