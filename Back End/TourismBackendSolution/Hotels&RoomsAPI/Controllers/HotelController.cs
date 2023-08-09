using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Hotels_RoomsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService<Hotel, int> _hotelService;
        private readonly ILogger<HotelController> _logger;

        public HotelController(IHotelService<Hotel, int> hotelService, ILogger<HotelController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        [Authorize(Roles = "Hotel Agent")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel)
        {
            try
            {
                var hotels = await _hotelService.Add(hotel);
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding hotel.");
                return BadRequest("An error occurred while adding hotel.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hotelService.Get(id);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotel by ID.");
                return BadRequest("An error occurred while fetching hotel by ID.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Hotel>>> GetAllHotels()
        {
            try
            {
                var hotels = await _hotelService.GetAll();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all hotels.");
                return BadRequest("An error occurred while fetching all hotels.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> DeleteHotels(int id)
        {
            try
            {
                var hotel = await _hotelService.Delete(id);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting hotel.");
                return BadRequest("An error occurred while deleting hotel.");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> UpdateHotel(Hotel hotel)
        {
            try
            {
                var hotels = await _hotelService.Update(hotel);
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating hotel.");
                return BadRequest("An error occurred while updating hotel.");
            }
        }

        [HttpGet("{cityName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Hotel>>> CityHotels(string cityName)
        {
            try
            {
                var hotels = await _hotelService.GetByCity(cityName);
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotels by city name.");
                return BadRequest("An error occurred while fetching hotels by city name.");
            }
        }

        [HttpGet("{stateName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Hotel>>> StateHotels(string stateName)
        {
            try
            {
                var hotels = await _hotelService.GetByState(stateName);
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotels by state name.");
                return BadRequest("An error occurred while fetching hotels by state name.");
            }
        }

        [HttpGet("{agentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Hotel>>> GetByAgent(int agentId)
        {
            try
            {
                var hotels = await _hotelService.GetByAgentId(agentId);
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching hotels by agent ID.");
                return BadRequest("An error occurred while fetching hotels by agent ID.");
            }
        }
    }
}
