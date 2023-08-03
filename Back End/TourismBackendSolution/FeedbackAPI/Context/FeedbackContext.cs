using FeedbackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackAPI.Context
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<FeedBack> FeedBacks { get; set; }
    }
}
