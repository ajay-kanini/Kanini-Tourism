using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService<Country, int, string> _countryService;
        private readonly ILocationService<State, int, string> _stateService;
        private readonly ILocationService<City, int, string> _cityService;

        public LocationController(
            ILocationService<Country, int, string> countryService,
            ILocationService<State, int, string> stateService,
            ILocationService<City, int, string> cityService)
        {
            _countryService = countryService;
            _stateService = stateService;
            _cityService = cityService;
        }

        [HttpPost("AddCountry")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Country>> AddCountry(Country item)
        {
            try
            {
                var country = await _countryService.AddLocation(item);
                return Ok(country);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to add");
        }

        [HttpGet("GetCountryById")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            try
            {
                var country = await _countryService.GetLocationById(id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to add");
        }

        [HttpGet("GetCountryByName")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Country>> GetCountryByName(string name)
        {
            try
            {
                var country = await _countryService.GetLocationByName(name);
                return Ok(country);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to fetch");
        }

        [HttpGet("GetAllCountry")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ICollection<LocationDTO>>> GetAllCountries()
        {
            try
            {
                var country = await _countryService.GetAllLocation();
                return Ok(country);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to fetch");
        }

        [HttpPost("AddState")]
        [ProducesResponseType(typeof(State), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<State>> AddState(State item)
        {
            try
            {
                var state = await _stateService.AddLocation(item);
                return Ok(state);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to add");
        }

        [HttpGet("GetStateById")]
        [ProducesResponseType(typeof(State), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<State>> GetStateById(int id)
        {
            try
            {
                var state = await _stateService.GetLocationById(id);
                return Ok(state);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to add");
        }

        [HttpGet("GetstateByName")]
        [ProducesResponseType(typeof(State), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<State>> GetStateByName(string name)
        {
            try
            {
                var state = await _stateService.GetLocationByName(name);
                return Ok(state);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to fetch");
        }

        [HttpGet("GetAllState")]
        [ProducesResponseType(typeof(State), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ICollection<LocationDTO>>> GetAllStates()
        {
            try
            {
                var state = await _stateService.GetAllLocation();
                return Ok(state);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to fetch");
        }

        [HttpPost("AddCity")]
        [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<City>> AddCity(City item)
        {
            try
            {
                var city = await _cityService.AddLocation(item);
                return Ok(city);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to add");
        }

        [HttpGet("GetCityById")]
        [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<City>> GetCityById(int id)
        {
            try
            {
                var country = await _cityService.GetLocationById(id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to add");
        }

        [HttpGet("GetCityByName")]
        [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<City>> GetCitryByName(string name)
        {
            try
            {
                var city = await _cityService.GetLocationByName(name);
                return Ok(city);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to fetch");
        }

        [HttpGet("GetAllCity")]
        [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ICollection<LocationDTO>>> GetAllCities()
        {
            try
            {
                var country = await _cityService.GetAllLocation();
                return Ok(country);
            }
            catch (Exception ex)
            {
                throw new Exception("Message", ex);
            }
            return BadRequest("Unable to fetch");
        }
    }
}
