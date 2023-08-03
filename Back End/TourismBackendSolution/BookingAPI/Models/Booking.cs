using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string  UserName { get; set; }
        public string  HotelName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int NumberOfDays
        {
            get
            {
                TimeSpan duration = EndDate - StartDate;
                return duration.Days + 1; // Adding 1 to include both start and end dates
            }
            private set { }
        }
        public Double TotalPrice { get; set; }
    }
}
