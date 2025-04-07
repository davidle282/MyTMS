using MyTMS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Service.BookingService
{
    public interface IBookingService
    {
        Task<IQueryable<Booking>> GetAllBookingsAsync();
    }
}
