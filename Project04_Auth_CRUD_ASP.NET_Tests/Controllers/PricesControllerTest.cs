using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Project04_Auth_CRUD_ASP.NET.Controllers;
using Project04_Auth_CRUD_ASP.NET.Data;
using Project04_Auth_CRUD_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project04_Auth_CRUD_ASP.NET_Tests.Controllers
{
    class PricesControllerTest
    {
        private ApplicationDbContext db;
        private Guid _Id;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            db = new ApplicationDbContext(options);

            _Id = new Guid("bdf275e0-ee5d-4e6b-87b2-59cde04713a8");
            db.Prices.Add(new PriceModel() { Id = _Id, Value = 3 });
            db.SaveChanges();
        }
        [Test]
        public async Task Delete_ReturnsViewResult_WhenVaildId()
        {
            // Arrange
            PricesController controller = new PricesController(db);

            // Act
            var result = await controller.Delete(new Guid("bdf275e0-ee5d-4e6b-87b2-59cde04713a8"));

            // Assert
            Assert.IsTrue(result is NotFoundResult);
            Assert.Pass();
        }

        [Test]
        public async Task Delete_ReturnsNotFound_WhenNullId()
        {
            // Arrange
            PricesController controller = new PricesController(db);

            // Act
            var result = await controller.Delete(null);

            // Assert
            Assert.IsTrue(result is NotFoundResult);
            Assert.Pass();
        }

        [Test]
        public async Task Delete_ReturnsViewResult_WhenInvaildId()
        {
            // Arrange
            PricesController controller = new PricesController(db);

            // Act
            var result = await controller.Delete(new Guid());

            // Assert
            Assert.IsTrue(result is NotFoundResult);
            Assert.Pass();
        }
    }
}
