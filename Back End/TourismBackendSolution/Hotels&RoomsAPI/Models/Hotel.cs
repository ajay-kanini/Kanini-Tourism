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

        public double ContactNumber { get; set; }
    }
}
