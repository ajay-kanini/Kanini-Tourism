using BookingAPI.Interfaces;
using BookingAPI.Models;

namespace BookingAPI.Services
{
    public class BookingService : IBookingService<Booking, int>
    {
        private readonly IBookingRepo<Booking, int> _repo;
        public BookingService(IBookingRepo<Booking, int> repo)
        {
            _repo = repo;
        }
        public async Task<Booking> Add(Booking item)
        {
            return await _repo.Add(item);
        }

        public async Task<Booking> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<Booking> Get(int id)
        {
           return await _repo.Get(id);
        }

        public async Task<ICollection<Booking>> GetBookingByHotelId(int id)
        {
            return await _repo.GetBookingByHotelId(id);
        }

        public async Task<Booking> GetByUserId(int id)
        {
            return await _repo.GetByUserId(id);
        }

        public async Task<Booking> Update(Booking item)
        {
            return await _repo.Update(item);
        }
    }
}
