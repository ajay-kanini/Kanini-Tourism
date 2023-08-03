using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Context
{
    public class IBookingService : DbContext
    {
        public IBookingService(DbContextOptions options) : base(options)  
        {
            
        }
        public DbSet<Booking> Bookings { get; set; }    
    }
}
