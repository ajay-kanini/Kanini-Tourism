using FeedbackAPI.Interfaces;
using FeedbackAPI.Models;
using FeedbackAPI.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService<FeedBack, int> _service;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(IFeedbackService<FeedBack, int> service, ILogger<FeedbackController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FeedBack>> AddFeedback(FeedBack feedBack)
        {
            try
            {
                var feedbacks = await _service.Add(feedBack);
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding feedback.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding feedback. Please try again later.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FeedBack>> GetFeedbackById(int id)
        {
            try
            {
                var feedbacks = await _service.Get(id);
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving feedback by id.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving feedback by id. Please try again later.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<FeedBack>>> GetFeedbackByHotelId(int id)
        {
            try
            {
                var feedbacks = await _service.GetByHotelId(id);
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving feedbacks by hotel id.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving feedbacks by hotel id. Please try again later.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<FeedBack>>> GetFeedbackByUserId(int id)
        {
            try
            {
                var feedbacks = await _service.GetByUserId(id);
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving feedbacks by user id.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving feedbacks by user id. Please try again later.");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FeedBack>> UpdateFeedback(FeedBack feedBack)
        {
            try
            {
                var feedbacks = await _service.Update(feedBack);
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating feedback.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating feedback. Please try again later.");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FeedBack>> DeleteFeedback(int id)
        {
            try
            {
                var feedbacks = await _service.Delete(id);
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting feedback.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting feedback. Please try again later.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<FeedBack>>> GetAllFeedbacks()
        {
            try
            {
                var feedbacks = await _service.GetAll();
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all feedbacks.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving all feedbacks. Please try again later.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UserExistence(int id)
        {
            try
            {
                var feedbacks = await _service.CheckUserExistence(id);
                if (feedbacks != false)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking user existence.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while checking user existence. Please try again later.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RatingDTO>> RatingCalculation(int id)
        {
            try
            {
                var feedbacks = await _service.CalculatePoints(id);
                if (feedbacks != null)
                {
                    return Ok(feedbacks);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calculating rating.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while calculating rating. Please try again later.");
            }
        }
    }
}
