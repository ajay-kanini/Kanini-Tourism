namespace BookingAPI.Interfaces
{
    public interface IBookingService<T, K>
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K id);
        public Task<T> Get(K id);
        public Task<T> GetByUserId(K id);
        public Task<ICollection<T>> GetBookingByHotelId(K id);
    }
}
