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

        public async Task<Room> BookOrCancelRoom(int id)
        {
            var room = await _repo.GetByRoomId(id);
            room.RoomAvailability = room.RoomAvailability == true ? false : true;
            await _repo.Update(room);   
            return room;
        }

        public async Task<ICollection<Room>> BookOrCancelMultipleRooms(int[] id)
        {
            var rooms = new List<Room>(); 
            foreach (var item in id)
            {
                var room = await BookOrCancelRoom(item);
                if (room != null)
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }
        public async Task<double> PriceCalculation(int numberOfDays, int[] roomId)
        {
            double totalRoomPrice = 0;

            foreach (var room in roomId)
            {
                var foundRoom = await _repo.GetByRoomId(room);

                if (foundRoom != null)
                {
                    double roomPrice = foundRoom.RoomPricePerDay * numberOfDays;
                    totalRoomPrice += roomPrice;
                }
            }

            double cgst = totalRoomPrice * 0.09;
            double sgst = totalRoomPrice * 0.09;

            double totalPrice = totalRoomPrice + cgst + sgst;
            return totalPrice;
        }

        public async Task<ICollection<Room>> GetMultipleRooms(int[] id)
        {
            var rooms = new List<Room>();
            foreach (var item in id)
            {
                var room = await _repo.GetByRoomId(item);
                if (room != null)
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public async Task<ICollection<Room>> AutoEndRoomTime(int[] roomId, DateTime endDate)
        {
            DateTime dt = DateTime.Now;
            var rooms = new List<Room>();
            foreach (var item in roomId)
            {
                var room = await _repo.GetByRoomId(item);
                if (room != null)
                {
                    rooms.Add(room);
                }
            }
            foreach (var room in rooms) 
            {
                if(room.RoomAvailability == false && dt >= endDate)
                {
                    room.RoomAvailability = true;
                }
                await _repo.Update(room);
            }
            return rooms;
        }
    }
}
