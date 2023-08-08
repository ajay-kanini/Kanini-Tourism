using Hotels_RoomsAPI.Context;
using Hotels_RoomsAPI.Interfaces;
using Hotels_RoomsAPI.Models;
using Hotels_RoomsAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class RoomRepoTest
    {
        private DbContextOptions<HotelsContext> GetDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<HotelsContext>()
                .UseInMemoryDatabase(databaseName: "roomInMemory")
                .Options;
            return options;
        }

        [TestMethod("Test get all rooms")]
        public async Task TestGetAllRooms()
        {
            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                context.Rooms?.Add(new Room
                {
                    RoomId = 1,
                    RoomPricePerDay = 100.0f,
                    ACAvailability = true,
                    NumberOfPersons = 2,
                    roomAvailability = true,
                    HotelId = 1,
                });

                context.Rooms?.Add(new Room
                {
                    RoomId = 2,
                    RoomPricePerDay = 120.0f,
                    ACAvailability = false,
                    NumberOfPersons = 3,
                    roomAvailability = true,
                    HotelId = 1,
                });

                await context.SaveChangesAsync();
            }

            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                ILogger<RoomRepo> logger = new LoggerFactory().CreateLogger<RoomRepo>();
                IRoomRepo<Room, int> repo = new RoomRepo(context, logger);
                var rooms = await repo.GetAll();
                Assert.AreEqual(2, rooms.Count);
            }
        }

        [TestMethod("Test add room")]
        public async Task TestAddRoom()
        {
            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                ILogger<RoomRepo> logger = new LoggerFactory().CreateLogger<RoomRepo>();
                IRoomRepo<Room, int> repo = new RoomRepo(context, logger);

                var room = new Room
                {
                    RoomId = 1,
                    RoomPricePerDay = 100.0f,
                    ACAvailability = true,
                    NumberOfPersons = 2,
                    roomAvailability = true,
                    HotelId = 1,
                };

                var addedRoom = await repo.Add(room);
                Assert.IsNotNull(addedRoom);

                var savedRoom = await context.Rooms.FirstOrDefaultAsync(r => r.RoomId == 1);
                Assert.IsNotNull(savedRoom);
                Assert.AreEqual(room.RoomId, savedRoom.RoomId);
            }
        }

        [TestMethod("Test delete room")]
        public async Task TestDeleteRoom()
        {
            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                context.Rooms?.Add(new Room
                {
                    RoomId = 1,
                    RoomPricePerDay = 100.0f,
                    ACAvailability = true,
                    NumberOfPersons = 2,
                    roomAvailability = true,
                    HotelId = 1,
                });

                await context.SaveChangesAsync();
            }

            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                ILogger<RoomRepo> logger = new LoggerFactory().CreateLogger<RoomRepo>();
                IRoomRepo<Room, int> repo = new RoomRepo(context, logger);

                var deletedRoom = await repo.Delete(1);
                Assert.IsNotNull(deletedRoom);

                var savedRoom = await context.Rooms.FirstOrDefaultAsync(r => r.RoomId == 1);
                Assert.IsNull(savedRoom);
            }
        }

        [TestMethod("Test get room by ID")]
        public async Task TestGetRoomById()
        {
            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                context.Rooms?.Add(new Room
                {
                    RoomId = 1,
                    RoomPricePerDay = 100.0f,
                    ACAvailability = true,
                    NumberOfPersons = 2,
                    roomAvailability = true,
                    HotelId = 1,
                });

                await context.SaveChangesAsync();
            }

            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                ILogger<RoomRepo> logger = new LoggerFactory().CreateLogger<RoomRepo>();
                IRoomRepo<Room, int> repo = new RoomRepo(context, logger);

                var room = await repo.GetByRoomId(1);
                Assert.IsNotNull(room);
                Assert.AreEqual(1, room.RoomId);
            }
        }

        [TestMethod("Test update room")]
        public async Task TestUpdateRoom()
        {
            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                context.Rooms?.Add(new Room
                {
                    RoomId = 1,
                    RoomPricePerDay = 100.0f,
                    ACAvailability = true,
                    NumberOfPersons = 2,
                    roomAvailability = true,
                    HotelId = 1,
                });

                await context.SaveChangesAsync();
            }

            using (var context = new HotelsContext(GetDbContextOptions()))
            {
                ILogger<RoomRepo> logger = new LoggerFactory().CreateLogger<RoomRepo>();
                IRoomRepo<Room, int> repo = new RoomRepo(context, logger);

                var room = await repo.GetByRoomId(1);
                Assert.IsNotNull(room);

                room.RoomPricePerDay = 120.0f;
                var updatedRoom = await repo.Update(room);
                Assert.IsNotNull(updatedRoom);
                Assert.AreEqual(120.0f, updatedRoom.RoomPricePerDay);

                var savedRoom = await context.Rooms.FirstOrDefaultAsync(r => r.RoomId == 1);
                Assert.IsNotNull(savedRoom);
                Assert.AreEqual(120.0f, savedRoom.RoomPricePerDay);
            }
        }
    }
}
