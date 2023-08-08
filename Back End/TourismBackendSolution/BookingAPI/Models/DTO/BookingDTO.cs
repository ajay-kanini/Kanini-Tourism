namespace BookingAPI.Models.DTO
{
    public class BookingDTO
    {
        public int bookingId { get; set; }
        public string? bookingStatus { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public int RoomId { get; set; }
        public double TotalPrice { get; set; }
        public bool cancelRoom { get; set; }
    }
}
