using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotels_RoomsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService<Hotel, int> _hotelService;
        public HotelsController(IHotelService<Hotel, int> hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel) 
        {
            var hotels = await _hotelService.Add(hotel);
            if(hotel != null) 
            {
                return Ok(hotels);
            }
            else
               return BadRequest("Unable to fetch");
        }

        [HttpGet]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            var hotel= await _hotelService.Get(id);
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
    }
}
