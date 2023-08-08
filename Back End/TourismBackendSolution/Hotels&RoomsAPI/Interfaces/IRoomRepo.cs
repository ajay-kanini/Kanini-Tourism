namespace Hotels_RoomsAPI.Interfaces
{
    public interface IRoomRepo<T, K>
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K id);
        public Task<T> GetByRoomId(K id);
        public Task<ICollection<T>> GetByHotelId(K id);
        public Task<ICollection<T>> GetAll();
    }
}
