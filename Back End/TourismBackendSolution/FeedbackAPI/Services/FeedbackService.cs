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

        public async Task<bool> CheckUserExistence(FeedBack feedBack)
        {
            var users = await _repo.GetAll();
            var checkUser =  users.FirstOrDefault(u=> u.UserId == feedBack.UserId);
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
