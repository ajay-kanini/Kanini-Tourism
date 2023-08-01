using Hotels_RoomsAPI.Models;

namespace Hotels_RoomsAPI.Interfaces
{
    public interface IHotelAmenityRepo<T>
    {
        public Task<HotelAmenity> Add(int hotelId, int[] amenitiesId);
        public Task<T> update(T item);
        
    }
}
