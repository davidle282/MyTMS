using MyTMS.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Data.Entities
{
    public partial class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTimeOffset? DOB { get; set; }
        public GenderTypeEnum? Gender { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Email { get; set; } = string.Empty;
        public string AuthId { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public virtual List<Booking> UserCreatedBookings { get; set; } = new List<Booking>();
    }
}
