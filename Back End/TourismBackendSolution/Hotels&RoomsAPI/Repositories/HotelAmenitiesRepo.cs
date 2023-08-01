using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels_RoomsAPI.Repositories
{
    public class HotelAmenitiesRepo : IHotelAmenityRepo<HotelAmenity>
    {
        private readonly HotelsContext _context;

        public HotelAmenitiesRepo(HotelsContext context)
        {
            _context = context;
        }
        public Task<HotelAmenity> Add(int hotelId, int[] amenitiesId)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == hotelId);
            if (hotel == null)
            {
                // Handle invalid hotelId, hotel not found
                return null; ;
            }

            HotelAmenity hotelAmenity = null; // Declare the variable outside the loop

            foreach (var amenityId in amenitiesId)
            {
                var amenity = _context.Amenities.FirstOrDefault(a => a.AmenityId == amenityId);
                if (amenity == null)
                {
                    // Handle invalid amenityId, amenity not found
                    continue;
                }

                // Check if the relationship already exists
                if (!_context.HotelsAmenities.Any(ha => ha.HotelId == hotelId && ha.AmenityId == amenityId))
                {
                    // Create the relationship
                    hotelAmenity = new HotelAmenity
                    {
                        HotelId = hotelId,
                        AmenityId = amenityId
                    };
                    _context.HotelsAmenities.Add(hotelAmenity);
                }
            }
            _context.SaveChanges();

            // The variable 'hotelAmenity' will hold the last created HotelAmenity
            return Task.FromResult(hotelAmenity);
        }

        public Task<HotelAmenity> update(HotelAmenity item)
        {
            throw new NotImplementedException();
        }
    }
}

