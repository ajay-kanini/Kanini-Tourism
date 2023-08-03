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
        public Task<T> BookOrCancelRoom(K id);
        public Task<ICollection<T>> BookOrCancelMultipleRooms(int[] id);
        public Task<ICollection<T>> GetMultipleRooms(int[] id);
        public Task<double> PriceCalculation(int NumberOfDays, int[] roomId);
        public Task<ICollection<T>> AutoEndRoomTime(int[] roomId, DateTime endDate);
    }
}
