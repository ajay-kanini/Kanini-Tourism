using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Hotels_RoomsAPI.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotels_RoomsAPI.Services
{
    public class RoomService : IRoomService<Room, int>
    {
        private readonly IRoomRepo<Room, int> _repo;
        private readonly ILogger<RoomService> _logger;

        public RoomService(IRoomRepo<Room, int> repo, ILogger<RoomService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Room> Add(Room item)
        {
            try
            {
                return await _repo.Add(item);
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
                return await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting room.");
                throw new Exception("An error occurred while deleting room.", ex);
            }
        }

        public async Task<ICollection<Room>> GetByHotelId(int id)
        {
            try
            {
                return await _repo.GetByHotelId(id);
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
                return await _repo.GetByRoomId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching room by room ID.");
                throw new Exception("An error occurred while fetching room by room ID.", ex);
            }
        }

        public async Task<ICollection<Room>> GetAll()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all rooms.");
                throw new Exception("An error occurred while fetching all rooms.", ex);
            }
        }

        public async Task<Room> Update(Room item)
        {
            try
            {
                return await _repo.Update(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating room.");
                throw new Exception("An error occurred while updating room.", ex);
            }
        }
    }
}
