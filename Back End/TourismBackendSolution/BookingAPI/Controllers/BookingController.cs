using BookingAPI.Context;
using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService<Booking, int> _service;

        public BookingController(IBookingService<Booking, int> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking(Booking booking)
        {
            var bookings = await _service.Add(booking);
            if(bookings == null) 
            {
                return BadRequest();
            }
            return Ok(bookings);    
        }

        [HttpGet]
        public async Task<ActionResult<Booking>> Get(int id)
        {
            var bookings = await _service.Get(id);
            if (bookings == null)
            {
                return BadRequest();
            }
            return Ok(bookings);
        }

        [HttpGet]
        public async Task<ActionResult<Booking>> GetByUserID(int id)
        {
            var bookings = await _service.GetByUserId(id);  
            if (bookings == null)
            {
                return BadRequest();
            }
            return Ok(bookings);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Booking>>> GetByHotelId(int id)
        {
            var bookings = await _service.GetBookingByHotelId(id);
            if (bookings == null)
            {
                return BadRequest();
            }
            return Ok(bookings);
        }

        [HttpGet]
        public async Task<ActionResult<Booking>> Delete(int id)
        {
            var bookings = await _service.Delete(id);
            if (bookings == null)
            {
                return BadRequest();
            }
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> UpdateBooking(Booking booking)
        {
            var bookings = await _service.Update(booking);
            if (bookings == null)
            {
                return BadRequest();
            }
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> UserCheck(int userId, int hotelId)
        {
            var bookings = await _service.CheckUserExistence(userId, hotelId);
            if (bookings == false)
            {
                return BadRequest();
            }
            return Ok(bookings);
        }
    }
}
