using HospitalManagement.Interface;
using HospitalManagement.Models;
using HospitalManagement.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class RegisterController : ControllerBase
    {
        private readonly IManageUsers _service;

        public RegisterController(IManageUsers service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO?>> RegisterHotelAgent(HotelAgentDTO agentDTO)
        {
            try
            {
                var agent = await _service.HotelAgentRegistration(agentDTO);
                if (agent != null)
                    return Created("Doctor Added", agent);
                else
                    return BadRequest("Unable to fetch");
            }
            catch (Exception ex)
            {
                // Log the exception or perform any other necessary actions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO?>> RegisterClient(ClientDTO clientDTO)
        {
            try
            {
                var client = await _service.ClientRegistration(clientDTO);
                if (client != null)
                    return Created("Client Added", client);
                else
                    return BadRequest("Unable to fetch");
            }
            catch (Exception ex)
            {
                // Log the exception or perform any other necessary actions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }

        //[Authorize(Roles="Admin")]

        [HttpPut]
        [ProducesResponseType(typeof(HotelAgent), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HotelAgent>> UpdateAgentStatus(HotelAgent agent)
        {
            try
            {
                var agents = await _service.UpdateAgents(agent);
                if (agents != null)
                    return Created("Agent Updated", agents);
                else
                    return BadRequest("Unable to fetch");
            }
            catch (Exception ex)
            {
                // Log the exception or perform any other necessary actions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> Login(UserDTO userDTO)
        {
            try
            {
                var agent = await _service.Login(userDTO);
                if (agent != null)
                    return Created("Agent Updated", agent);
                else
                    return BadRequest("Unable to fetch");
            }
            catch (Exception ex)
            {
                // Log the exception or perform any other necessary actions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HotelAgent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HotelAgent>> GetAgentDetails()
        {
            try
            {
                var agent = await _service.GetAllAgents();
                if (agent != null)
                    return Ok(agent);
                else
                    return BadRequest("Unable to fetch");
            }
            catch (Exception ex)
            {
                // Log the exception or perform any other necessary actions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HotelAgent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HotelAgent>> GetOneAgent(int key)
        {
            try
            {
                var agent = await _service.GetAgent(key);
                if (agent != null)
                    return Ok(agent);
                else
                    return BadRequest("Unable to fetch");
            }
            catch (Exception ex)
            {
                // Log the exception or perform any other necessary actions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Clients), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HotelAgent>> GetOneClient(int key)
        {
            try
            {
                var client = await _service.GetClient(key);
                if (client != null)
                    return Ok(client);
                else
                    return BadRequest("Unable to fetch");
            }
            catch (Exception ex)
            {
                // Log the exception or perform any other necessary actions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred: " + ex.Message);
            }
        }
    }
}
