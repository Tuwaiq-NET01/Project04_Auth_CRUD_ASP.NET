using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelREservationManagementTest.Controller
{
    class HotelsControllerTest
    {
        private HotelsControllerTest hotelsController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;
            var context = new ApplicationDbContext(options);

           
            context.Database.EnsureDeleted();
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
