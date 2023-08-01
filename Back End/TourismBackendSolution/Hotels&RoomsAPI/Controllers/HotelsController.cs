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
        private readonly IHotelRepo<Hotel, int> _hotelRepo;
        public HotelsController(IHotelRepo<Hotel, int> hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel) 
        {
            var hotels = await _hotelRepo.Add(hotel);
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
            var hotel= await _hotelRepo.Get(id);
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
            var hotels = await _hotelRepo.GetAll();
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
            var hotel = await _hotelRepo.Delete(id);
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
            var hotels = await _hotelRepo.Update(hotel);
            if (hotel != null)
            {
                return Ok(hotels);
            }
            else
                return BadRequest("Unable to fetch");
        }
    }
}
