using FeedbackAPI.Context;
using FeedbackAPI.Interfaces;
using FeedbackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedbackAPI.Repositories
{
    public class FeedbackRepo : IFeedbackRepo<FeedBack, int>
    {
        private readonly FeedbackContext _context;
        private readonly ILogger<FeedbackRepo> _logger;

        public FeedbackRepo(FeedbackContext context, ILogger<FeedbackRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<FeedBack> Add(FeedBack item)
        {
            try
            {
                _context.FeedBacks.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding the feedback.");
                throw new Exception("An error occurred while adding the feedback. Please try again later.");
            }
        }

        public async Task<FeedBack> Delete(int id)
        {
            try
            {
                var feedback = await Get(id);
                if (feedback != null)
                {
                    _context.FeedBacks.Remove(feedback);
                    await _context.SaveChangesAsync();
                }
                return feedback;
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
                var feedback = await _context.FeedBacks.FirstOrDefaultAsync(u => u.FeedbackId == id);
                return feedback;
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
                var feedbacks = await _context.FeedBacks.ToListAsync();
                return feedbacks;
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
                var feedbacks = await GetAll();
                var hotelFeedbacks = feedbacks.Where(u => u.HotelId == id).ToList();
                return hotelFeedbacks;
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
                var feedbacks = await GetAll();
                var userFeedbacks = feedbacks.Where(u => u.UserId == id).ToList();
                return userFeedbacks;
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
                var feedback = await Get(item.FeedbackId);
                feedback.FeedbackDescription = item.FeedbackDescription;
                feedback.Points = item.Points;
                await _context.SaveChangesAsync();
                return feedback;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the feedback.");
                throw new Exception("An error occurred while updating the feedback. Please try again later.");
            }
        }
    }
}
