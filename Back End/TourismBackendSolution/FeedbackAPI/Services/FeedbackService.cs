using FeedbackAPI.Interfaces;
using FeedbackAPI.Models;
using FeedbackAPI.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAPI.Services
{
    public class FeedbackService : IFeedbackService<FeedBack, int>
    {
        private readonly IFeedbackRepo<FeedBack, int> _repo;
        private readonly ILogger<FeedbackService> _logger;

        public FeedbackService(IFeedbackRepo<FeedBack, int> repo, ILogger<FeedbackService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<FeedBack> Add(FeedBack item)
        {
            try
            {
                return await _repo.Add(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding the feedback.");
                throw new Exception("An error occurred while adding the feedback. Please try again later.");
            }
        }

        public async Task<RatingDTO> CalculatePoints(int id)
        {
            try
            {
                var ratingDTO = new RatingDTO();
                var feedbacks = await _repo.GetByHotelId(id);
                var count = feedbacks.Count();

                double totalPoints = 0;

                foreach (var feedback in feedbacks)
                {
                    totalPoints += feedback.Points;
                }

                double averageRating = (double)totalPoints / count;

                ratingDTO.FeedBackCount = count;
                ratingDTO.FeedBackRating = averageRating;

                return ratingDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calculating feedback points.");
                throw new Exception("An error occurred while calculating feedback points. Please try again later.");
            }
        }

        public async Task<bool> CheckUserExistence(int id)
        {
            try
            {
                var users = await _repo.GetAll();
                var checkUser = users.FirstOrDefault(u => u.UserId == id);
                return checkUser != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking user existence.");
                throw new Exception("An error occurred while checking user existence. Please try again later.");
            }
        }

        public async Task<FeedBack> Delete(int id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting the feedback.");
                throw new Exception("An error occurred while deleting the feedback. Please try again later.");
            }
        }

        public async Task<FeedBack> Get(int id)
        {
            try
            {
                return await _repo.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving the feedback.");
                throw new Exception("An error occurred while retrieving the feedback. Please try again later.");
            }
        }

        public async Task<ICollection<FeedBack>> GetAll()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all feedbacks.");
                throw new Exception("An error occurred while retrieving all feedbacks. Please try again later.");
            }
        }

        public async Task<ICollection<FeedBack>> GetByHotelId(int id)
        {
            try
            {
                return await _repo.GetByHotelId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving feedbacks by hotel id.");
                throw new Exception("An error occurred while retrieving feedbacks by hotel id. Please try again later.");
            }
        }

        public async Task<ICollection<FeedBack>> GetByUserId(int id)
        {
            try
            {
                return await _repo.GetByUserId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving feedbacks by user id.");
                throw new Exception("An error occurred while retrieving feedbacks by user id. Please try again later.");
            }
        }

        public async Task<FeedBack> Update(FeedBack item)
        {
            try
            {
                return await _repo.Update(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the feedback.");
                throw new Exception("An error occurred while updating the feedback. Please try again later.");
            }
        }
    }
}
