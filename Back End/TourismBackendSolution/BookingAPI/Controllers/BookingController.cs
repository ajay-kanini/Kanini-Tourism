using BookingAPI.Context;
using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService<Booking, int> _service;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService<Booking, int> service, ILogger<BookingController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Booking>> AddBooking(Booking booking)
        {
            try
            {
                var bookings = await _service.Add(booking);
                if (bookings == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(Get), new { id = bookings.BookingId }, bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding booking.");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Booking>> Get(int id)
        {
            try
            {
                var bookings = await _service.Get(id);
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching booking by ID.");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Booking>>> GetByUserID(int id)
        {
            try
            {
                var bookings = await _service.GetByUserId(id);
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching bookings by UserID.");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Booking>>> GetByHotelId(int id)
        {
            try
            {
                var bookings = await _service.GetBookingByHotelId(id);
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching bookings by HotelID.");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Booking>> Delete(int id)
        {
            try
            {
                var bookings = await _service.Delete(id);
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting booking.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Booking>> UpdateBooking(Booking booking)
        {
            try
            {
                var bookings = await _service.Update(booking);
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating booking.");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookingDTO>> CancelBookings(int id)
        {
            try
            {
                var bookings = await _service.CancelRoom(id);
                if (bookings == null)
                {
                    return NotFound();
                }
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while canceling bookings.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> BookRooms(BookingDTO bookingDTO)
        {
            try
            {
                var bookings = await _service.BookRoom(bookingDTO);
                if (!bookings)
                {
                    return BadRequest(false);
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while booking rooms.");
                return BadRequest(ex.Message);
            }
        }
    }
}
