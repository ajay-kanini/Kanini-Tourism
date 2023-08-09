using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Hotels_RoomsAPI.Models.DTO;
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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService<Room, int> _roomServie;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomService<Room, int> roomService, ILogger<RoomController> logger)
        {
            _roomServie = roomService;
            _logger = logger;
        }

        [Authorize(Roles = "Hotel Agent")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Room>> AddRoom(Room room)
        {
            try
            {
                var rooms = await _roomServie.Add(room);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding room.");
                return BadRequest("An error occurred while adding room.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Room>> GetRoomByRoomID(int id)
        {
            try
            {
                var rooms = await _roomServie.GetByRoomId(id);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching room by RoomID.");
                return BadRequest("An error occurred while fetching room by RoomID.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Room>>> GetRoomByHotelID(int id)
        {
            try
            {
                var rooms = await _roomServie.GetByHotelId(id);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching rooms by HotelID.");
                return BadRequest("An error occurred while fetching rooms by HotelID.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Room>>> GetAllRooms()
        {
            try
            {
                var rooms = await _roomServie.GetAll();
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all rooms.");
                return BadRequest("An error occurred while fetching all rooms.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Room>> DeleteRooms(int id)
        {
            try
            {
                var rooms = await _roomServie.Delete(id);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting room.");
                return BadRequest("An error occurred while deleting room.");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Room>> UpdateRooms(Room room)
        {
            try
            {
                var rooms = await _roomServie.Update(room);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating room.");
                return BadRequest("An error occurred while updating room.");
            }
        }
    }
}
