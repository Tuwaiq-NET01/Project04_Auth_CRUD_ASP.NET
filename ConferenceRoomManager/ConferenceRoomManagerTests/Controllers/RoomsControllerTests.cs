using ConferenceRoomManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConferenceRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ConferenceRoomManager.Models;

namespace ConferenceRoomManager.Controllers.Tests
{
    [TestFixture]
    public class RoomsControllerTests
    {

        private DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ConferenceRoomManager")
            .Options;
        private RoomsController controller;

        [SetUp]
        public void SetUp()
        {
            
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            
            controller = new RoomsController(context);
            seed(context);
        }

        public void seed(ApplicationDbContext context)
        {

            List<RoomModel> rooms = new List<RoomModel>()
            {
                new RoomModel(){
                    Id = 1, Name = "R1", Description = "R1 desc",
                BuildingId = 1, Capacity = 1, Image = "img.jpg"
                }
            };
            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }

        [Test]
        public void Index_Test_Returns_Number_of_Data_In_ViewData()
        {
            //Test the number of data that is passed thru viewdata
            
            var result = controller.Index() as ViewResult;
            var rooms = result.ViewData;
            
            Assert.AreEqual(1, rooms.Count);
            
        }
    }
}