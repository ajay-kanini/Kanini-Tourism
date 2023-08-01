using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels_RoomsAPI.Repositories
{
    public class RoomRepo : IRoomRepo<Room, int>
    {
        private readonly HotelsContext _context;

        public RoomRepo(HotelsContext context)
        {
            _context = context;
        }
        public async Task<Room> Add(Room item)
        {
            try
            {
                _context.Rooms.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
        }

        public async Task<Room> Delete(int id)
        {
            var room = await GetByRoomId(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<ICollection<Room>> GetAll()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<ICollection<Room>> GetByHotelId(int id)
        {
            var rooms = await GetAll();
            var hotelRooms = rooms.Where(u => u.HotelId == id).ToList();
            return hotelRooms;
        }

        public async Task<Room> GetByRoomId(int id)
        {
            var hotel = await _context.Rooms.FirstOrDefaultAsync(u => u.RoomId == id);
            return hotel;
        }

        public async Task<Room> Update(Room item)
        {
            var room = await GetByRoomId(item.HotelId);
            room.RoomPrice = item.RoomPrice;
            room.ACAvailability = item.ACAvailability;
           _context.SaveChanges();
            return room;
        }
    }
}
