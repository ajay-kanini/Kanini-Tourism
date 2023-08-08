using System;
using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }

        public string? UserName { get; set; }

        public int HotelId { get; set; }

        public string? HotelName { get; set; }

        public int RoomId { get; set; }

        [Required(ErrorMessage = "CheckIn date is required.")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "CheckOut date is required.")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }
        public string? BookingStatus { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "NumberOfDays must be greater than or equal to 1.")]
        public int? NumberOfDays
        {
            get
            {
                TimeSpan duration = CheckOut - CheckIn;
                return duration.Days + 1;
            }
        }
        public double TotalPrice { get; set; }
    }
}
