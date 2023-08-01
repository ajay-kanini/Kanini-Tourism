using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.Repositories
{
    public class CountryRepo : ILocationRepo<Country, int, string>
    {
        private readonly TourLocationContext _context;

        public CountryRepo(TourLocationContext context)
        {
            _context = context;
        }

        public async Task<Country> Add(Country item)
        {
            try
            {
                _context.Countries.Add(item);
                await _context.SaveChangesAsync();
                return item;
            } 
            catch (Exception ex) 
            {
                throw new Exception("Message", ex);
            }
        }

        public async Task<Country> Delete(int id)
        {
            var country = await GetById(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<Country> GetById(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(u=>u.Id == id);
            return country;
        }

        public async Task<ICollection<LocationDTO>> GetAll()
        {
            var countries = await _context.Countries.Select(city => new LocationDTO { Id = city.Id, Name = city.Name }).ToListAsync();
            return countries;
        }

        public Task<Country> Update(Country item)
        {
            throw new NotImplementedException();
        }

        public async Task<Country> GetByName(string name)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(u => u.Name.ToLower() == name.ToLower());
            return country;
        }

    }
}
