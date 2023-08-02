using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
    }
}
