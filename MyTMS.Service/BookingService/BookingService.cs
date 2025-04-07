using Firebase.Auth.Repository;
using Firebase.Auth;
using MyTMS.Data.Entities;
using MyTMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTMS.Service.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        public BookingService(
            IRepository<Booking> bookingRepository
        )
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<IQueryable<Booking>> GetAllBookingsAsync()
        {
            var result = await _bookingRepository.GetAllAsync();
            return result;
        }
    }
}
