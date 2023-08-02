#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels_RoomsAPI.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public double RoomPrice { get; set; }
        public bool ACAvailability { get; set; }

        [Range(minimum: 1, maximum: 5)]
        public int NumberOfPersons { get; set; }
        
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        
    }
}
