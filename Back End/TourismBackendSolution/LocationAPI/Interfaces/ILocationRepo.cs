using LocationAPI.Models.DTO;

namespace LocationAPI.Interfaces
{
    public interface ILocationRepo<T,K,C>
    {
        public Task<T> Add(T item);
        public Task<T> GetById(K id);
        public Task<T> Delete(K id);   
        public Task<T> Update(T item);  
        public Task<T> GetByName(C name);
        public Task<ICollection<LocationDTO>> GetAll();

    }
}
