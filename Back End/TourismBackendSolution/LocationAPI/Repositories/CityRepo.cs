#nullable disable
using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.Repositories
{
    public class CityRepo : ILocationRepo<City, int, string>
    {
        private readonly TourLocationContext _context;

        public CityRepo(TourLocationContext context)
        {
            _context = context;
        }
        public async Task<City> Add(City item)
        {
            try
            {
                _context.Cities.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
        }

        public async Task<City> Delete(int id)
        {
            var city = await GetById(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<ICollection<LocationDTO>> GetAll()
        {
            var cities = await _context.Cities.Where(state => state.CountryName.ToLower() == "india").Select(city => new LocationDTO { Id = city.Id, Name = city.Name }).ToListAsync();
            //var city = await _context.Cities.ToListAsync();
            return cities;
        }

        public async Task<City> GetById(int id)
        {
            var city = await _context.Cities.Where(state => state.CountryName.ToLower() == "india").FirstOrDefaultAsync(u => u.Id == id);
            return city;
        }

        public async Task<City> GetByName(string name)
        {
            var city = await _context.Cities.Where(state => state.CountryName.ToLower() == "india").FirstOrDefaultAsync(u => u.Name.ToLower().Trim() == name.ToLower().Trim());
            return city;
        }

        public Task<City> Update(City item)
        {
            throw new NotImplementedException();
        }
    }
}
