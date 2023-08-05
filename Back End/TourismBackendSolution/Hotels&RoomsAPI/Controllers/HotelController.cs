using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotels_RoomsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]

    public class HotelController : ControllerBase
    {
        private readonly IHotelService<Hotel, int> _hotelService;
        public HotelController(IHotelService<Hotel, int> hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel)
        {
            var hotels = await _hotelService.Add(hotel);
            if (hotel != null)
            {
                return Ok(hotels);
            }
            else
                return BadRequest("Unable to fetch");
        }

        [HttpGet]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            var hotel = await _hotelService.Get(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            else
                return BadRequest("Unable to fetch");
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Hotel>>> GetAllHotels()
        {
            var hotels = await _hotelService.GetAll();
            if (hotels != null)
            {
                return Ok(hotels);
            }
            else
                return BadRequest("Unable to fetch");
        }

        [HttpDelete]
        public async Task<ActionResult<Hotel>> DeleteHotels(int id)
        {
            var hotel = await _hotelService.Delete(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            else
                return BadRequest("Unable to fetch");
        }

        [HttpPut]
        public async Task<ActionResult<Hotel>> UpdateHotel(Hotel hotel)
        {
            var hotels = await _hotelService.Update(hotel);
            if (hotel != null)
            {
                return Ok(hotels);
            }
            else
                return BadRequest("Unable to fetch");
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Hotel>>> CityHotels(string cityName)
        {
            var hotels = await _hotelService.GetByCity(cityName);
            if (hotels != null)
            {
                return Ok(hotels);
            }
            else
                return BadRequest("Unable to fetch");
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Hotel>>> StateHotels(string stateName)
        {
            var hotels = await _hotelService.GetByState(stateName);
            if (hotels != null)
            {
                return Ok(hotels);
            }
            else
                return BadRequest("Unable to fetch");
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Hotel>>> GetByAgent(int agentId)
        {
            var hotels = await _hotelService.GetByAgentId(agentId);
            if (hotels != null)
            {
                return Ok(hotels);
            }
            return BadRequest("Unable to fetch");
        }
        //[HttpGet]
        //public async Task<ActionResult<ICollection<Hotel>>> GetByAgent(int agentId)
        //{
        //    var hotels = await _hotelService.GetByAgentId(agentId);
        //    if (hotels != null)
        //    {
        //        return Ok(hotels);
        //    }
        //    else
        //        return BadRequest("Unable to fetch");
        //}
    }
}
