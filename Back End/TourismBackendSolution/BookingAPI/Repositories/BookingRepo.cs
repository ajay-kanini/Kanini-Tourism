using BookingAPI.Interfaces;
using BookingAPI.Models;

namespace BookingAPI.Repositories
{
    public class BookingRepo : IBoolkingRepo<Booking, int>
    {
        public Task<Booking> Add(Booking item)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Booking>> GetBookingByHotelId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> Update(Booking item)
        {
            throw new NotImplementedException();
        }
    }
}
