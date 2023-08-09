using BookingAPI.Context;
using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Services
{
    public class BookingService : IBookingService<Booking, int>
    {
        private readonly IBookingRepo<Booking, int> _repo;
        private readonly ILogger<BookingService> _logger;

        public BookingService(IBookingRepo<Booking, int> repo, ILogger<BookingService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Booking> Add(Booking item)
        {
            try
            {
                return await _repo.Add(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding booking.");
                throw new Exception("An error occurred while adding booking.", ex);
            }
        }

        public async Task<BookingDTO> CancelRoom(int id)
        {
            var bookingDTO = new BookingDTO();
            try
            {
                var booking = await _repo.Get(id);

                DateTime currentDateTime = DateTime.Now;
                if (booking.CheckIn <= currentDateTime.AddHours(24))
                {
                    bookingDTO.cancelRoom = false;
                }
                else
                {
                    booking.BookingStatus = "Cancelled";
                    bookingDTO.cancelRoom = true;
                    await _repo.Update(booking);
                }
                return bookingDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while canceling room booking.");
                throw new Exception("An error occurred while canceling room booking.", ex);
            }
        }

        public async Task<Booking?> Delete(int id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting booking.");
                throw new Exception("An error occurred while deleting booking.", ex);
            }
        }

        public async Task<Booking> Get(int id)
        {
            try
            {
                return await _repo.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching booking by ID.");
                throw new Exception("An error occurred while fetching booking by ID.", ex);
            }
        }

        public async Task<ICollection<Booking>> GetBookingByHotelId(int id)
        {
            try
            {
                return await _repo.GetBookingByHotelId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching bookings by HotelID.");
                throw new Exception("An error occurred while fetching bookings by HotelID.", ex);
            }
        }

        public async Task<ICollection<Booking>> GetByUserId(int id)
        {
            try
            {
                return await _repo.GetByUserId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching bookings by UserID.");
                throw new Exception("An error occurred while fetching bookings by UserID.", ex);
            }
        }

        public async Task<Booking> Update(Booking item)
        {
            try
            {
                return await _repo.Update(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating booking.");
                throw new Exception("An error occurred while updating booking.", ex);
            }
        }

        public async Task<bool> BookRoom(BookingDTO bookingDTO)
        {
            try
            {
                var bookings = await _repo.GetAll();
                bool isConflict = bookings.Any(booking =>
                    booking.RoomId == bookingDTO.RoomId &&
                    booking.BookingStatus != "Booked" && 
                    !(booking.CheckOut <= bookingDTO.checkIn || booking.CheckIn >= bookingDTO.checkOut)
                );

                if (isConflict)
                {
                    return false;
                }
                else
                {
                    Booking book = new()
                    {
                        HotelId = bookingDTO.HotelId,
                        RoomId = bookingDTO.RoomId,
                        HotelName = bookingDTO.HotelName,
                        UserId = bookingDTO.UserId,
                        UserName = bookingDTO.UserName,
                        CheckIn = bookingDTO.checkIn,
                        CheckOut = bookingDTO.checkOut,
                        TotalPrice = bookingDTO.TotalPrice,
                        BookingStatus = "Booked" 
                    };
                    await _repo.Add(book);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while booking room.");
                throw new Exception("An error occurred while booking room.", ex);
            }
        }
    }
}
