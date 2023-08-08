using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels_RoomsAPI.Services
{
    public class HotelService : IHotelService<Hotel, int>
    {
        private readonly IHotelRepo<Hotel, int> _repo;
        private readonly ILogger<HotelService> _logger;

        public HotelService(IHotelRepo<Hotel, int> repo, ILogger<HotelService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Hotel> Add(Hotel item)
        {
            try
            {
                return await _repo.Add(item);
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
                return await _repo.Delete(id);
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
                return await _repo.Get(id);
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
                return await _repo.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all hotels.");
                throw new Exception("An error occurred while fetching all hotels.", ex);
            }
        }

        public async Task<ICollection<Hotel>> GetByAgentId(int id)
        {
            try
            {
                var hotels = await _repo.GetAll();
                var agentHotels = hotels.Where(h => h.AgentId == id).ToList();
                return agentHotels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotels by agent ID.");
                throw new Exception("An error occurred while fetching hotels by agent ID.", ex);
            }
        }

        public async Task<ICollection<Hotel>> GetByCity(string cityName)
        {
            try
            {
                var hotels = await _repo.GetAll();
                var cityHotels = hotels.Where(u => u.City == cityName).ToList();
                return cityHotels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotels by city name.");
                throw new Exception("An error occurred while fetching hotels by city name.", ex);
            }
        }

        public async Task<ICollection<Hotel>> GetByState(string stateName)
        {
            try
            {
                var hotels = await _repo.GetAll();
                var stateHotels = hotels.Where(u => u.State == stateName).ToList();
                return stateHotels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotels by state name.");
                throw new Exception("An error occurred while fetching hotels by state name.", ex);
            }
        }

        public async Task<Hotel> Update(Hotel item)
        {
            try
            {
                return await _repo.Update(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating hotel.");
                throw new Exception("An error occurred while updating hotel.", ex);
            }
        }
    }
}
