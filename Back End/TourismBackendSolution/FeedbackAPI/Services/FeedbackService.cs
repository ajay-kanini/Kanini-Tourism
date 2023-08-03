using FeedbackAPI.Interfaces;
using FeedbackAPI.Models;

namespace FeedbackAPI.Services
{
    public class FeedbackService : IFeedbackService<FeedBack, int>
    {
        private readonly IFeedbackRepo<FeedBack, int> _repo;

        public FeedbackService(IFeedbackRepo<FeedBack, int> repo)
        {
            _repo = repo;
        }
        public async Task<FeedBack> Add(FeedBack item)
        {
           return await _repo.Add(item);
        }

        public async Task<double> CalculatePoints(int id)
        {
            var feedbacks = await _repo.GetByHotelId(id);
            var count = feedbacks.Count();

            if (count == 0)
            {
                return 0; 
            }

            double totalPoints = 0;

            foreach (var feedback in feedbacks)
            {
                totalPoints += feedback.Points; 
            }

            double averageRating = (double)totalPoints / count;

            return averageRating;
        }

        public async Task<bool> CheckUserExistence(int id)
        {
            var users = await _repo.GetAll();
            var checkUser =  users.FirstOrDefault(u=> u.UserId == id);
            var result = checkUser != null ?  true :  false;
            return result;
        }

        public async Task<FeedBack> Delete(int id)
        {
            return await _repo.Delete(id);    
        }

        public async Task<FeedBack> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<ICollection<FeedBack>> GetAll()
        {
            return await _repo.GetAll();    
        }

        public async Task<ICollection<FeedBack>> GetByHotelId(int id)
        {
            return await _repo.GetByHotelId(id);
        }

        public async Task<ICollection<FeedBack>> GetByUserId(int id)
        {
            return await _repo.GetByUserId(id);   
        }

        public async Task<FeedBack> Update(FeedBack item)
        {
            return await _repo.Update(item);
        }
    }
}
