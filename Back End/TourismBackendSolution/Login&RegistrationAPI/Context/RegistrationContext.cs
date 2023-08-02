using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Context
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<HotelAgent>? HotelAgents { get; set; } 
        public DbSet<Clients>? Clients { get; set; }   
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.Mail })
                .IsUnique(true);
        }
    }
}
