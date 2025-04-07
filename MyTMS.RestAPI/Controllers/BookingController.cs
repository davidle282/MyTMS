using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTMS.Data.Entities;
using MyTMS.Service.BookingService;


namespace MyTMS.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController: ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //[Authorize]
        [HttpGet]
        public async Task<List<Booking>> GetAllBookings()
        {
            return (await _bookingService.GetAllBookingsAsync()).ToList();

        }
    }
}
