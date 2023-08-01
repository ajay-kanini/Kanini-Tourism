using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels_RoomsAPI.Repositories
{
    public class AmenityRepo : IAmenityRepo<Amenity, int>
    {
        private readonly HotelsContext _context;

        public AmenityRepo(HotelsContext context)
        {
            _context = context;
        }
        public async Task<Amenity> Add(Amenity item)
        {
            try
            {
                _context.Amenities.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
        }

        public async Task<Amenity> Delete(int id)
        {
            var amenity = await Get(id);
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<Amenity> Get(int id)
        {
            var amenity = await _context.Amenities.FirstOrDefaultAsync(u => u.AmenityId == id);
            return amenity;
        }

        public async Task<ICollection<Amenity>> GetAll()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> Update(Amenity item)
        {
            var amenity = await Get(item.AmenityId);
            amenity.AmenityName = item.AmenityName;
            _context.SaveChangesAsync();
            return amenity;
        }
    }
}

