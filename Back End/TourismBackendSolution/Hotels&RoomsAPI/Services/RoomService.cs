using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;

namespace Hotels_RoomsAPI.Services
{
    public class RoomService : IRoomService<Room, int>
    {
        private readonly IRoomRepo<Room, int> _repo;

        public RoomService(IRoomRepo<Room, int> repo)
        {
            _repo = repo;
        }
        public async Task<Room> Add(Room item)
        {
            return await _repo.Add(item);
        }

        public async Task<Room> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<ICollection<Room>> GetByHotelId(int id)
        {
            return await _repo.GetByHotelId(id);
        }
        public async Task<Room> GetByRoomId(int id)
        {
            return await _repo.GetByRoomId(id);
        }

        public async Task<ICollection<Room>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Room> Update(Room item)
        {
            return await _repo.Update(item);
        }

        public async Task<Room> RoomStatus(int id)
        {
            var room = await _repo.GetByRoomId(id);
            room.RoomAvailability = room.RoomAvailability == false ? true : false;
            await _repo.Update(room);   
            return room;
        }
    }
}
