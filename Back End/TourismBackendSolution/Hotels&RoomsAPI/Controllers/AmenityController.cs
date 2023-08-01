using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotels_RoomsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityRepo<Amenity, int> _amenityService;

        public AmenityController(IAmenityRepo<Amenity, int> amenityService)
        {
            _amenityService = amenityService;
        }
        [HttpPost]
        public async Task<ActionResult<Amenity>> AddAmenity(Amenity amenity)
        {
            var amenities = await _amenityService.Add(amenity);
            if (amenities != null)
            {
                return Ok(amenities);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<Amenity>> GetById(int id)
        {
            var amenities = await _amenityService.Get(id);
            if (amenities != null) 
            {
                return Ok(amenities);   
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Amenity>>> GetAllAmenities()
        {
            var amenities = await _amenityService.GetAll();
            if (amenities != null)
            {
                return Ok(amenities);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Amenity>> UpdateAmenity(Amenity amenity)
        {
            var amenities = await _amenityService.Update(amenity);
            if (amenities != null)
            {
                return Ok(amenities);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
        {
            var amenities = await _amenityService.Delete(id);
            if (amenities != null)
            {
                return Ok(amenities);
            }
            return BadRequest();
        }
    }
}
