using BookingAPI.Context;
using BookingAPI.Interfaces;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Repositories
{
    public class BookingRepo : IBookingRepo<Booking, int>
    {
        private readonly IBookingService _context;
        public BookingRepo(IBookingService context)
        {
            _context = context;
        }
        public async Task<Booking> Add(Booking item)
        {
            try
            {
                _context.Bookings.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex) 
            {
                throw new Exception("Message", ex);
            }
        }

        public async Task<Booking> Delete(int id)
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

        public async Task<Booking> Get(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(u=>u.BookingId == id);
            return booking;
        }

        public async Task<ICollection<Booking>> GetAll()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<ICollection<Booking>> GetBookingByHotelId(int id)
        {
            var bookings = await _context.Bookings.ToListAsync();
            var hotelBookings = bookings.Where(u=>u.HotelId == id).ToList();
            return hotelBookings;
        }

        public async Task<Booking> GetByUserId(int id)
        {
            var bookings = await _context.Bookings.OrderByDescending(b => b.EndDate).ToListAsync();
            var userBooking = bookings.FirstOrDefault(u => u.UserId == id); 
            return userBooking;
        }

        public async Task<Booking> Update(Booking item)
        {
            var booking = await Get(item.BookingId);
            booking.StartDate = item.StartDate;
            booking.EndDate = item.EndDate; 
            booking.UserName = item.UserName;
            booking.HotelName = item.HotelName; 
            await _context.SaveChangesAsync();  
            return booking;
        }
    }
}
