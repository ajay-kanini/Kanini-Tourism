#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Hotels_RoomsAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public ICollection<HotelAmenity> HotelAmenities { get; set; }
        public string HotelDescription { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public double ContactNumber { get; set; }
    }
}
