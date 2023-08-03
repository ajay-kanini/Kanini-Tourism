using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.Models
{
    public class FeedBack
    {
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public string? FeedbackDescription { get; set;}
        
        [Range(minimum:1, maximum:5)]
        public double Points { get; set; }
    }
}
