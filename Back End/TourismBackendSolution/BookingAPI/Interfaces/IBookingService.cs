using BookingAPI.Models.DTO;

namespace BookingAPI.Interfaces
{
    public interface IBookingService<T, K>
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T?> Delete(K id);
        public Task<T> Get(K id);
        public Task<ICollection<T>> GetByUserId(K id);
        public Task<ICollection<T>> GetBookingByHotelId(K id);
         public Task<bool> BookRoom(BookingDTO bookingDTO);
        public Task<BookingDTO> CancelRoom(int id);

    }
}
