using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hotels_RoomsAPI.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public float RoomPricePerDay { get; set; }
        public bool ACAvailability { get; set; }
        public bool RoomAvailability { get; set; }

        [Range(minimum: 1, maximum: 5)]
        public int NumberOfPersons { get; set; }
        public int? HotelId { get; set; }

        [ForeignKey("HotelId")]

        [JsonIgnore]
        public Hotel? Hotel { get; set; }
        
    }
}
