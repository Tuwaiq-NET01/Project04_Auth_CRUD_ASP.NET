using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Keraa.Data;
using Keraa.Controllers;
using Keraa.Models;
using Microsoft.Extensions.Configuration;

namespace mininetests.Controllers
{
    public class ChatRoomsControllerTest
    {
        private ChatRoomsController _rooms;
        private UserManager<ApplicationUser> _userManager;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestKeraa").Options;
            var _db = new ApplicationDbContext(options);
            _db.Database.EnsureDeleted();
            _rooms = new ChatRoomsController(_db, _userManager);
            seedingDeta(_db);
        }

        public void seedingDeta(ApplicationDbContext _db)
        {
            ChatRoomModel[] rooms = new[]
            {
                new ChatRoomModel { Id = 1, RoomId = "77", ProductOwnerId="14", OtherId="10"}
            };
            _db.ChatRooms.AddRange(
                rooms
            );
            _db.SaveChanges();
        }

        [Test]
        public void Test_Room_With_Invalid_Id()
        {
            BadRequestResult bad_request = new BadRequestResult();

            var result = _rooms.Room("5").Result as BadRequestResult;
            Assert.AreEqual(bad_request.StatusCode, result.StatusCode);
        }
        [Test]
        public void Test_Room_With_Empty_Id()
        {
            BadRequestResult bad_request = new BadRequestResult();

            var result = _rooms.Room(null).Result as BadRequestResult;
            Assert.AreEqual(bad_request.StatusCode, result.StatusCode);
        }
        [Test]
        public void Test_Room_With_Valid_Id()
        {
            var result = _rooms.Room("77").Result as ViewResult;
            Assert.AreEqual("Room", result);
        }
    }
}