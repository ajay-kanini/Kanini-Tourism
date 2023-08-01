using LocationAPI.Models.DTO;

namespace LocationAPI.Interfaces
{
    public interface ILocationService<T, K, C>
    {
        public Task<T> AddLocation(T item);
        public Task<T> DeleteLocation(K id);
        public Task<ICollection<LocationDTO>> GetAllLocation();
        public Task<T> GetLocationById(K id);
        public Task<T> GetLocationByName(C name);
        public Task<T> UpdateLocation(T item);

    }
}
