﻿using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotels_RoomsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo<Room, int> _roomServie;

        public RoomController(IRoomRepo<Room, int> roomService)
        {
            _roomServie = roomService;
        }
        [HttpPost]
        public async Task<ActionResult<Room>> AddRoom(Room room)
        {
            var rooms = await _roomServie.Add(room);
            if(rooms != null)
            {
                return Ok(rooms);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<Room>> GetRoomByRoomID(int id)
        {
            var rooms = await _roomServie.GetByRoomId(id);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Room>>> GetRoomByHotelID(int id)
        {
            var rooms = await _roomServie.GetByHotelId(id);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Room>>> GetAllRooms()
        {
            var rooms = await _roomServie.GetAll();
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<Room>> DeleteRooms(int id)
        {
            var rooms = await _roomServie.Delete(id);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Room>> UpdateRooms(Room room)
        {
            var rooms = await _roomServie.Update(room);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return BadRequest();
        }

    }
}