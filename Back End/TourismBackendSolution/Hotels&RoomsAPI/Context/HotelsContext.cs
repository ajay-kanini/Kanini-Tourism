#nullable disable
using Hotels_RoomsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels_RoomsAPI.Context
{
    public class HotelsContext : DbContext
    {
        public HotelsContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }  
        
    }
}
