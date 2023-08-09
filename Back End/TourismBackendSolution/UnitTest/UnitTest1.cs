#nullable disable
using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Hotels_RoomsAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class HotelRepoTest
    {
        private HotelsContext _hotelContext;
        public static DbContextOptions<HotelsContext> GetDbContextOptions()
        {
            var contextOptions = new DbContextOptionsBuilder<HotelsContext>()
                                    .UseInMemoryDatabase(databaseName: "hotelInMemory")
                                    .Options;
            return contextOptions;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _hotelContext = new HotelsContext(GetDbContextOptions());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _hotelContext.Dispose();
        }

        [TestMethod]
        public async Task TestAddHotel()
        {
            using var hotelContext = new HotelsContext(GetDbContextOptions());
            var hotelRepo = new HotelRepo(hotelContext, new Logger<HotelRepo>(new LoggerFactory()));

            var hotel = new Hotel
            {
                HotelName = "Sample Hotel",
                HotelDescription = "Sample Description",
                City = "Sample City",
                State = "Sample State",
                Address = "Sample Address",
                ContactNumber = "1234567890",
                AgentId = 1
            };

            var addedHotel = await hotelRepo.Add(hotel);

            Assert.IsNotNull(addedHotel);
            Assert.AreEqual("Sample Hotel", addedHotel.HotelName);
            Assert.AreEqual("Sample Description", addedHotel.HotelDescription);
            Assert.AreEqual("Sample City", addedHotel.City);
            Assert.AreEqual("Sample State", addedHotel.State);
            Assert.AreEqual("Sample Address", addedHotel.Address);
            Assert.AreEqual("1234567890", addedHotel.ContactNumber);
            Assert.AreEqual(1, addedHotel.AgentId);
        }

        [TestMethod]
        public async Task TestGetHotel()
        {
            using var hotelContext = new HotelsContext(GetDbContextOptions());
            var hotelRepo = new HotelRepo(hotelContext, new Logger<HotelRepo>(new LoggerFactory()));

            var hotel = new Hotel
            {
                HotelName = "Sample Hotel",
                HotelDescription = "Sample Description",
                City = "Sample City",
                State = "Sample State",
                Address = "Sample Address",
                ContactNumber = "1234567890",
                AgentId = 1
            };

            var addedHotel = await hotelRepo.Add(hotel);

            var fetchedHotel = await hotelRepo.Get(addedHotel.HotelId);

            Assert.IsNotNull(fetchedHotel);
            Assert.AreEqual(addedHotel.HotelId, fetchedHotel.HotelId);
            Assert.AreEqual("Sample Hotel", fetchedHotel.HotelName);
            Assert.AreEqual("Sample Description", fetchedHotel.HotelDescription);
            Assert.AreEqual("Sample City", fetchedHotel.City);
            Assert.AreEqual("Sample State", fetchedHotel.State);
            Assert.AreEqual("Sample Address", fetchedHotel.Address);
            Assert.AreEqual("1234567890", fetchedHotel.ContactNumber);
            Assert.AreEqual(1, fetchedHotel.AgentId);
        }

        [TestMethod]
        public async Task TestGetAllHotels()
        {
            using var hotelContext = new HotelsContext(GetDbContextOptions());
            var hotelRepo = new HotelRepo(hotelContext, new Logger<HotelRepo>(new LoggerFactory()));

            var hotel1 = new Hotel
            {
                HotelName = "Hotel 1",
                City = "City 1",
                State = "State 1",
                Address = "Address 1",
                ContactNumber = "1111111111",
                AgentId = 1
            };

            var hotel2 = new Hotel
            {
                HotelName = "Hotel 2",
                City = "City 2",
                State = "State 2",
                Address = "Address 2",
                ContactNumber = "2222222222",
                AgentId = 2
            };

            await hotelRepo.Add(hotel1);
            await hotelRepo.Add(hotel2);

            var allHotels = await hotelRepo.GetAll();

            Assert.IsNotNull(allHotels);
            Assert.AreEqual(2, allHotels.Count);
        }

        [TestMethod]
        public async Task TestUpdateHotel()
        {
            using var hotelContext = new HotelsContext(GetDbContextOptions());
            var hotelRepo = new HotelRepo(hotelContext, new Logger<HotelRepo>(new LoggerFactory()));

            var hotel = new Hotel
            {
                HotelName = "Sample Hotel",
                HotelDescription = "Sample Description",
                City = "Sample City",
                State = "Sample State",
                Address = "Sample Address",
                ContactNumber = "1234567890",
                AgentId = 1
            };

            var addedHotel = await hotelRepo.Add(hotel);

            addedHotel.HotelName = "Updated Hotel Name";
            addedHotel.HotelDescription = "Updated Description";
            addedHotel.City = "Updated City";
            addedHotel.State = "Updated State";
            addedHotel.Address = "Updated Address";
            addedHotel.ContactNumber = "9876543210";
            addedHotel.AgentId = 2;

            var updatedHotel = await hotelRepo.Update(addedHotel);

            Assert.IsNotNull(updatedHotel);
            Assert.AreEqual("Updated Hotel Name", updatedHotel.HotelName);
            Assert.AreEqual("Updated Description", updatedHotel.HotelDescription);
            Assert.AreEqual("Updated City", updatedHotel.City);
            Assert.AreEqual("Updated State", updatedHotel.State);
            Assert.AreEqual("Updated Address", updatedHotel.Address);
            Assert.AreEqual("9876543210", updatedHotel.ContactNumber);
            Assert.AreEqual(2, updatedHotel.AgentId);
        }

        [TestMethod]
        public async Task TestDeleteHotel()
        {
            using var hotelContext = new HotelsContext(GetDbContextOptions());
            var hotelRepo = new HotelRepo(hotelContext, new Logger<HotelRepo>(new LoggerFactory()));

            var hotel = new Hotel
            {
                HotelName = "Sample Hotel",
                HotelDescription = "Sample Description",
                City = "Sample City",
                State = "Sample State",
                Address = "Sample Address",
                ContactNumber = "1234567890",
                AgentId = 1
            };

            var addedHotel = await hotelRepo.Add(hotel);

            var deletedHotel = await hotelRepo.Delete(addedHotel.HotelId);

            Assert.IsNotNull(deletedHotel);
            Assert.AreEqual(addedHotel.HotelId, deletedHotel.HotelId);
        }
    }
}
