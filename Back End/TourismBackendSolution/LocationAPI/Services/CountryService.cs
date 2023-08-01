using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTO;

namespace LocationAPI.Services
{
    public class CountryService : ILocationService<Country, int, string>
    {
        private readonly ILocationRepo<Country, int, string> _repo;

        public CountryService(ILocationRepo<Country, int, string> repo)
        {
            _repo = repo;
        }
        public async Task<Country> AddLocation(Country item)
        {
            return await _repo.Add(item);
        }

        public async Task<Country> DeleteLocation(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<ICollection<LocationDTO>> GetAllLocation()
        {
            return await _repo.GetAll();
        }

        public async Task<Country> GetLocationById(int id)
        {
            return await _repo.GetById(id); 
        }

        public async Task<Country> GetLocationByName(string name)
        {
            return await _repo.GetByName(name);
        }

        public Task<Country> UpdateLocation(Country item)
        {
            throw new NotImplementedException();
        }
    }
}
