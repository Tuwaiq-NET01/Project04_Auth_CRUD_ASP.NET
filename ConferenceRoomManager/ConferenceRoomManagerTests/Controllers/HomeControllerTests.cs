
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
    public class HomeControllerTests
    {
        private DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ConferenceRoomManager")
            .Options;
        private HomeController controller;

        [SetUp]
        public void SetUp()
        {

            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();

            controller = new HomeController(context);

        }

        [Test]
        public void Privacy_Test_Returns_Privacy_View()
        {
            
            var result = controller.Privacy() as ViewResult;

            Assert.AreEqual("Privacy", result.ViewName);
        }
    }
}