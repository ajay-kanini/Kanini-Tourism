using FeedbackAPI.Context;
using FeedbackAPI.Interfaces;
using FeedbackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackAPI.Repositories
{
    public class FeedbackRepo : IFeedbackRepo<FeedBack, int>
    {
        private readonly FeedbackContext _context;
        public FeedbackRepo(FeedbackContext context)
        {
            _context = context; 
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
                throw new Exception("Message", ex);
            }
        }

        public async Task<FeedBack> Delete(int id)
        {
            var feedback = await Get(id);
            if (feedback != null) 
            {
                _context.FeedBacks.Remove(feedback);
                await _context.SaveChangesAsync();            
            }
            return feedback;
        }

        public async Task<FeedBack> Get(int id)
        {
            var feedback = await _context.FeedBacks.FirstOrDefaultAsync(u=> u.FeedbackId == id);
            return feedback;
        }

        public async Task<ICollection<FeedBack>> GetAll()
        {
            var feedbacks = await _context.FeedBacks.ToListAsync();
            return feedbacks;   
        }

        public async Task<ICollection<FeedBack>> GetByHotelId(int id)
        {
            var feedbacks = await GetAll();
            var hotelFeedbacks = feedbacks.Where(u=> u.HotelId == id).ToList();  
            return hotelFeedbacks; 
        }

        public async Task<ICollection<FeedBack>> GetByUserId(int id)
        {
            var feedbacks = await GetAll();
            var hotelFeedbacks = feedbacks.Where(u => u.UserId == id).ToList();
            return hotelFeedbacks;
        }

        public async Task<FeedBack> Update(FeedBack item)
        {
            var feedback = await Get(item.FeedbackId);
            feedback.FeedbackDescription = item.FeedbackDescription;
            feedback.Points = item.Points;
            _context.SaveChangesAsync();
            return feedback;
        }
    }
}
