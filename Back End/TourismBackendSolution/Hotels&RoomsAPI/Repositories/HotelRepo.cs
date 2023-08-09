using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotels_RoomsAPI.Repositories
{
    public class HotelRepo : IHotelRepo<Hotel, int>
    {
        private readonly HotelsContext _context;
        private readonly ILogger<HotelRepo> _logger;

        public HotelRepo(HotelsContext context, ILogger<HotelRepo> logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.LogError(ex, "Error occurred while adding hotel.");
                throw new Exception("An error occurred while adding hotel.", ex);
            }
        }

        public async Task<Hotel> Delete(int id)
        {
            try
            {
                var hotel = await Get(id);
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting hotel.");
                throw new Exception("An error occurred while deleting hotel.", ex);
            }
        }

        public async Task<Hotel> Get(int id)
        {
            try
            {
                var hotel = await _context.Hotels.FirstOrDefaultAsync(u => u.HotelId == id);
                return hotel ?? throw new Exception("Hotel is null");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotel by ID.");
                throw new Exception("An error occurred while fetching hotel by ID.", ex);
            }
        }

        public async Task<ICollection<Hotel>> GetAll()
        {
            try
            {
                var hotels = await _context.Hotels.ToListAsync();
                return hotels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all hotels.");
                throw new Exception("An error occurred while fetching all hotels.", ex);
            }
        }

        public async Task<Hotel> Update(Hotel item)
        {
            try
            {
                var hotel = await Get(item.HotelId);
                hotel.HotelName = item.HotelName;
                hotel.HotelDescription = item.HotelDescription;
                hotel.ContactNumber = item.ContactNumber;
                hotel.Address = item.Address;
                hotel.City = item.City;
                hotel.State = item.State;
                await _context.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating hotel.");
                throw new Exception("An error occurred while updating hotel.", ex);
            }
        }
    }
}
