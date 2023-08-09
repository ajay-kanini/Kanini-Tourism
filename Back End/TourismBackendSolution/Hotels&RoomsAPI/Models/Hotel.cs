using System.ComponentModel.DataAnnotations;

namespace Hotels_RoomsAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "HotelName is required.")]
        [StringLength(100, ErrorMessage = "HotelName must not exceed 100 characters.")]
        public string? HotelName { get; set; }

        [StringLength(500, ErrorMessage = "HotelDescription must not exceed 500 characters.")]
        public string? HotelDescription { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City must not exceed 100 characters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(100, ErrorMessage = "State must not exceed 100 characters.")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(500, ErrorMessage = "Address must not exceed 500 characters.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "ContactNumber is required.")]
        [RegularExpression(@"^\+?[0-9]{1,3}-?[0-9]{3,4}-?[0-9]{3,4}$", ErrorMessage = "Invalid ContactNumber format.")]
        public string? ContactNumber { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "AgentId must be greater than 0.")]
        public int? AgentId { get; set; }
        public string? image { get; set; }
    }
}
