using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels_RoomsAPI.Models
{
    public class HotelAmenity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }
}
