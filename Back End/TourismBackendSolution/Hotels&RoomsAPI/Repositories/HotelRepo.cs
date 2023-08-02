using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels_RoomsAPI.Repositories
{
    public class HotelRepo : IHotelRepo<Hotel, int>
    {
        private readonly HotelsContext _context;

        public HotelRepo(HotelsContext context )
        {
            _context = context;
        }
        public async Task<Hotel> Add(Hotel item)
        {
            try
            {
                _context.Hotels.Add(item);
                await _context.SaveChangesAsync();
                return item;    
            }
            catch (Exception ex) 
            {
                throw new Exception("Message", ex);
            }    
        }

        public async Task<Hotel> Delete(int id)
        {
            var hotel = await Get(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();  
            return hotel;
        }

        public async Task<Hotel> Get(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(u=>u.HotelId == id);
            return hotel;
        }

        public async Task<ICollection<Hotel>> GetAll()
        {
            var hotels = await _context.Hotels.ToListAsync();   
            return hotels;  
        }

        public async Task<Hotel> Update(Hotel item)
        {
            var hotel = await Get(item.HotelId);
            hotel.HotelName = item.HotelName;
            hotel.HotelDescription = item.HotelDescription;
            hotel.ContactNumber = item.ContactNumber;
            hotel.Address = item.Address;
            hotel.City = item.City;
            hotel.State = item.State;   
            _context.SaveChanges();
            return hotel;
        }
    }
}
