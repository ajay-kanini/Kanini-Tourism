using System.ComponentModel.DataAnnotations;

namespace Hotels_RoomsAPI.Models
{
    public class Amenity
    {
        [Key]
        public int AmenityId { get; set; }
        public string AmenityName { get; set; }

        public ICollection<HotelAmenity> HotelAmenity { get; set; }

    }
}
