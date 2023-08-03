using FeedbackAPI.Interfaces;
using FeedbackAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService<FeedBack, int> _service;
        public FeedbackController(IFeedbackService<FeedBack, int> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<FeedBack>> AddFeedback(FeedBack feedBack)
        {
            var feedbacks = await _service.Add(feedBack);
            if(feedbacks != null)
            {
                return Ok(feedbacks);   
            }
            return BadRequest();    
        }
        [HttpGet]
        public async Task<ActionResult<FeedBack>> GetFeedbackById(int id)
        {
            var feedbacks = await _service.Get(id);
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<FeedBack>>> GetFeedbackByHotelId(int id)
        {
            var feedbacks = await _service.GetByHotelId(id);
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<FeedBack>>> GetFeedbackByUserId(int id)
        {
            var feedbacks = await _service.GetByUserId(id);
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<FeedBack>> UpdateFeedback(FeedBack feedBack)
        {
            var feedbacks = await _service.Update(feedBack);
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<FeedBack>> DeleteFeedback(int id)
        {
            var feedbacks = await _service.Delete(id);
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<FeedBack>>> GetAllFeedbacks()
        {
            var feedbacks = await _service.GetAll();
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<bool>> UserExistence(int id)
        {
            var feedbacks = await _service.CheckUserExistence(id); 
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<double>> RatingCalculation(int id)
        {
            var feedbacks = await _service.CalculatePoints(id);
            if (feedbacks != null)
            {
                return Ok(feedbacks);
            }
            return BadRequest();
        }

    }
}
