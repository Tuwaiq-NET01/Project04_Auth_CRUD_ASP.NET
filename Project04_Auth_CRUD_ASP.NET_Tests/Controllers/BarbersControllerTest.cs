using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Project04_Auth_CRUD_ASP.NET.Data;
using Project04_Auth_CRUD_ASP.NET.Controllers;
using Project04_Auth_CRUD_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Project04_Auth_CRUD_ASP.NET_Tests
{
    class BarbersControllerTest
    {
        private ApplicationDbContext db;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

                db = new ApplicationDbContext(options);
        }

        [Test]
        public async Task Create_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            BarbersController controller = new BarbersController(db);
            BarberModel barber = new BarberModel() { Name = "Ahmed", Id = new System.Guid() };

            // Act
            var result = await controller.Create(barber);

            // Assert
            Assert.IsTrue(result is RedirectToActionResult);
            Assert.Pass();
        }

        [Test]
        public async Task Create_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            BarbersController controller = new BarbersController(db);
            BarberModel barber = new BarberModel();
            controller.ModelState.AddModelError("BarberName", "Required");

            // Act
            var result = await controller.Create(barber);

            // Assert
            Assert.IsTrue(result is ViewResult);
            Assert.Pass();
        }
    }
}
