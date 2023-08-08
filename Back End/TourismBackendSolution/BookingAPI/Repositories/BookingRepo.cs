using BookingAPI.Context;
using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingAPI.Repositories
{
    public class BookingRepo : IBookingRepo<Booking, int>
    {
        private readonly IBookingService _context;
        private readonly ILogger<BookingRepo> _logger;

        public BookingRepo(IBookingService context, ILogger<BookingRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Booking> Add(Booking item)
        {
            try
            {
                item.BookingStatus = "Booked";
                _context.Bookings.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding booking.");
                throw new Exception("An error occurred while adding booking. Please try again later.", ex);
            }
        }

        public async Task<Booking> Delete(int id)
        {
            try
            {
                var booking = await Get(id);
                if (booking != null)
                {
                    _context.Remove(booking);
                    await _context.SaveChangesAsync();
                    return booking;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting booking.");
                throw new Exception("An error occurred while deleting booking. Please try again later.", ex);
            }
        }

        public async Task<Booking> Get(int id)
        {
            try
            {
                var booking = await _context.Bookings.FirstOrDefaultAsync(u => u.BookingId == id);
                return booking;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving booking by id.");
                throw new Exception("An error occurred while retrieving booking by id. Please try again later.", ex);
            }
        }

        public async Task<ICollection<Booking>> GetAll()
        {
            try
            {
                var bookings = await _context.Bookings.ToListAsync();
                return bookings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all bookings.");
                throw new Exception("An error occurred while retrieving all bookings. Please try again later.", ex);
            }
        }

        public async Task<ICollection<Booking>> GetBookingByHotelId(int id)
        {
            try
            {
                var bookings = await _context.Bookings.ToListAsync();
                var hotelBookings = bookings.Where(u => u.HotelId == id).ToList();
                return hotelBookings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving bookings by hotel id.");
                throw new Exception("An error occurred while retrieving bookings by hotel id. Please try again later.", ex);
            }
        }

        public async Task<ICollection<Booking>> GetByUserId(int id)
        {
            try
            {
                var bookings = await _context.Bookings.OrderByDescending(b => b.CheckOut).ToListAsync();
                return bookings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving bookings by user id.");
                throw new Exception("An error occurred while retrieving bookings by user id. Please try again later.", ex);
            }
        }

        public async Task<Booking> Update(Booking item)
        {
            try
            {
                var booking = await Get(item.BookingId);
                booking.CheckIn = item.CheckIn;
                booking.CheckOut = item.CheckOut;
                booking.UserName = item.UserName;
                booking.HotelName = item.HotelName;
                await _context.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating booking.");
                throw new Exception("An error occurred while updating booking. Please try again later.", ex);
            }
        }
    }
}
