using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.Models
{
    public class FeedBack
    {
        public int FeedbackId { get; set; }

        public int UserId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Mail { get; set; }

        public int HotelId { get; set; }

        [Required(ErrorMessage = "FeedbackDescription is required.")]
        public string? FeedbackDescription { get; set; }

        [Required(ErrorMessage = "Points is required.")]
        [Range(1, 5, ErrorMessage = "Points must be between 1 and 5.")]
        public double Points { get; set; }
    }
}
