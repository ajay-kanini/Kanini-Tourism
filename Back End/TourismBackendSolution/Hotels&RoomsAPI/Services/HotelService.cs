using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;

namespace Hotels_RoomsAPI.Services
{
    public class HotelService : IHotelService<Hotel, int>
    {
        private readonly IHotelRepo<Hotel, int> _repo;
        public HotelService(IHotelRepo<Hotel, int> repo)
        {
            _repo = repo;
        }
        public async Task<Hotel> Add(Hotel item)
        {
            return await _repo.Add(item); 
        }

        public async Task<Hotel> Delete(int id)
        {
            return await _repo.Delete(id);    
        }

        public async Task<Hotel> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<ICollection<Hotel>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Hotel> Update(Hotel item)
        {
            return await _repo.Update(item);
        }
    }
}
