using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTO;

namespace LocationAPI.Services
{
    public class CityService : ILocationService<City, int, string>
    {
        private readonly ILocationRepo<City, int, string> _repo;

        public CityService(ILocationRepo<City, int, string> repo)
        {
            _repo = repo;
        }
        public async Task<City> AddLocation(City item)
        {
            return await _repo.Add(item);
        }

        public async Task<City> DeleteLocation(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<ICollection<LocationDTO>> GetAllLocation()
        {
            return await _repo.GetAll();
        }

        public async Task<City> GetLocationById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<City> GetLocationByName(string name)
        {
            return await _repo.GetByName(name);
        }

        public Task<City> UpdateLocation(City item)
        {
            throw new NotImplementedException();
        }
    }
}
