using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotels_RoomsAPI.Models
{
    public class Amenity
    {
        [Key]
        public int AmenityId { get; set; }
        public string AmenityName { get; set; }

        [JsonIgnore]
        public ICollection<HotelAmenity>? HotelAmenity { get; set; }

    }
}
