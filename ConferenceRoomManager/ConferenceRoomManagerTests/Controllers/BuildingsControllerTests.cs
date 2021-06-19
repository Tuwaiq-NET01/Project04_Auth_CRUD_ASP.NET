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
    public class BuildingsControllerTests
    {

        private DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ConferenceRoomManager")
            .Options;
        private BuildingsController controller;

        [SetUp]
        public void SetUp()
        {

            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();

            controller = new BuildingsController(context);

        }
        [Test]
        public void Index_Test_Returns_View()
        {

            var result = controller.Index() as ViewResult;
            
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}