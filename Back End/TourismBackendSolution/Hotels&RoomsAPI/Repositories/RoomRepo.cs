using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels_RoomsAPI.Repositories
{
    public class RoomRepo : IRoomRepo<Room, int>
    {
        private readonly HotelsContext _context;
        private readonly ILogger<RoomRepo> _logger;

        public RoomRepo(HotelsContext context, ILogger<RoomRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Room> Add(Room item)
        {
            try
            {
                item.roomAvailability = true;
                _context.Rooms.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding room.");
                throw new Exception("An error occurred while adding room.", ex);
            }
        }

        public async Task<Room> Delete(int id)
        {
            try
            {
                var room = await GetByRoomId(id);
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return room;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting room.");
                throw new Exception("An error occurred while deleting room.", ex);
            }
        }

        public async Task<ICollection<Room>> GetAll()
        {
            try
            {
                var rooms = await _context.Rooms.ToListAsync();
                return rooms;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all rooms.");
                throw new Exception("An error occurred while fetching all rooms.", ex);
            }
        }

        public async Task<ICollection<Room>> GetByHotelId(int id)
        {
            try
            {
                var rooms = await GetAll();
                var hotelRooms = rooms.Where(u => u.HotelId == id).ToList();
                return hotelRooms;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching rooms by hotel ID.");
                throw new Exception("An error occurred while fetching rooms by hotel ID.", ex);
            }
        }

        public async Task<Room> GetByRoomId(int id)
        {
            try
            {
                var room = await _context.Rooms.FirstOrDefaultAsync(u => u.RoomId == id) ?? throw new Exception("Room is null");
                return room;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching room by room ID.");
                throw new Exception("An error occurred while fetching room by room ID.", ex);
            }
        }

        public async Task<Room> Update(Room item)
        {
            try
            {
                var room = await GetByRoomId(item.RoomId);
                room.RoomPricePerDay = item.RoomPricePerDay;
                room.ACAvailability = item.ACAvailability;
                room.NumberOfPersons = item.NumberOfPersons;
                await _context.SaveChangesAsync();
                return room;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating room.");
                throw new Exception("An error occurred while updating room.", ex);
            }
        }
    }
}
