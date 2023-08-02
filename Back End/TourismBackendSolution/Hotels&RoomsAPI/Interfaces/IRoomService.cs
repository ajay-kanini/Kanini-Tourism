namespace Hotels_RoomsAPI.Interfaces
{
    public interface IRoomService<T, K>
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K id);
        public Task<ICollection<T>> GetByHotelId(K id);
        public Task<T> GetByRoomId(K id);    
        public Task<ICollection<T>> GetAll();
        public Task<T> RoomStatus(K id);
        public Task<ICollection<T>> BookMultipleRooms(int[] id);
    }
}
