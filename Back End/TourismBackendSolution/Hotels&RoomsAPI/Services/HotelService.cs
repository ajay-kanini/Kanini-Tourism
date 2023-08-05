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

        public async Task<ICollection<Hotel>> GetByAgentId(int id)
        {
            var hotels = await _repo.GetAll();
            var agentHotels = hotels.Where(h => h.AgentId == id).ToList();
            return agentHotels;
        }

        public async Task<ICollection<Hotel>> GetByCity(string cityName)
        {
            var hotels = await _repo.GetAll();
            var cityHotels = hotels.Where(u => u.City == cityName).ToList();
            return cityHotels;
        }

        public async Task<ICollection<Hotel>> GetByState(string stateName)
        {
            var hotels = await _repo.GetAll();
            var stateHotels = hotels.Where(u => u.State == stateName).ToList();
            return stateHotels;
        }

        public async Task<Hotel> Update(Hotel item)
        {
            return await _repo.Update(item);
        }
    }
}
