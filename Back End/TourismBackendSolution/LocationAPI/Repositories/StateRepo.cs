using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.Repositories
{
    public class StateRepo : ILocationRepo<State, int, string>
    {
        private readonly TourLocationContext _context;

        public StateRepo(TourLocationContext context)
        {
            _context = context;
        }
        public async Task<State> Add(State item)
        {
            try
            {
                _context.States.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
        }

        public async Task<State> Delete(int id)
        {
            var state = await GetById(id);
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
            return state;
        }

        public async Task<ICollection<LocationDTO>> GetAll()
        {
            var state = await _context.States.Select(city => new LocationDTO { Id = city.Id, Name = city.Name }).ToListAsync(); ;
            return state;
        }

        public async Task<State> GetById(int id)
        {
            var state = await _context.States.FirstOrDefaultAsync(u => u.Id == id);
            return state;
        }
        public async Task<State> GetByName(string name)
        {
            var state = await _context.States.FirstOrDefaultAsync(u => u.Name.ToLower() == name.ToLower());
            return state;
        }

        public Task<State> Update(State item)
        {
            throw new NotImplementedException();
        }
    }
}
