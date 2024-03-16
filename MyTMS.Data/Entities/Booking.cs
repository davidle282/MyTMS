using MyTMS.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Entities
{
    public partial class Booking : BaseEntity
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;

        public string Vehicle { get; set; } = string.Empty;


    }
}
