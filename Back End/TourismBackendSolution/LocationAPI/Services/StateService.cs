using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTO;
using LocationAPI.Repositories;

namespace LocationAPI.Services
{
    public class StateService : ILocationService<State, int, string>
    {
        private readonly ILocationRepo<State, int, string> _repo;

        public StateService(ILocationRepo<State, int, string> repo)
        {
            _repo = repo;
        }
        public async Task<State> AddLocation(State item)
        {
            return await _repo.Add(item);
        }

        public async Task<State> DeleteLocation(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<ICollection<LocationDTO>> GetAllLocation()
        {
            return await _repo.GetAll();
        }

        public async Task<State> GetLocationById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<State> GetLocationByName(string name)
        {
            return await _repo.GetByName(name);
        }

        public Task<State> UpdateLocation(State item)
        {
            throw new NotImplementedException();
        }
    }
}
