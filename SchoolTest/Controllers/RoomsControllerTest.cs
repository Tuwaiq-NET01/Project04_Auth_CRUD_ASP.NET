using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using School.Controllers;
using School.Data;
using School.Models;
namespace SchoolTest.Controllers
{
    [TestFixture]
    class RoomsControllerTest
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "School")
           .Options;
        private RoomsController controller;

        [OneTimeSetUp]
        public void SetUp()
        {
            SeedDb();

            controller = new RoomsController(new ApplicationDbContext(dbContextOptions));
        }

        private void SeedDb()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            var rooms = new List<Room>
            {
                new Room {RoomId = 1, RoomSize="Large" },
                new Room {RoomId = 2, RoomSize="Small" },
                new Room {RoomId = 3, RoomSize="Medium" }
            };
            context.AddRange(rooms);
            context.SaveChanges();
        }

        [Test]
        public void IndexTest_WithData()
        {
            var result = controller.Index() as ViewResult;

            /*
             * Expecting Viewdata to contain 3 different values
             * one for added
             * one for deleted
             * and one for rooms
             */
            Assert.AreEqual(3, result.ViewData.Count());


            /*
             * Expecting 3 Rooms to be in viewdata
             */

            Assert.AreEqual(3, ((List<Room>)result.ViewData["Rooms"]).Count);

        }
    }
}
