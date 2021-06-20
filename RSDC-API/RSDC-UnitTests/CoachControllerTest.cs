using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSDC_API;
using RSDC_API.Controllers;
using RSDC_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RSDC_UnitTests
{
    public class CoachControllerTest : IDisposable
    {

        protected readonly RSDCContext _context;

        public CoachControllerTest()
        {
            var options = new DbContextOptionsBuilder<RSDCContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RSDCContext(options);

            _context.Database.EnsureCreated();

            var coaches = new[]
            {
                new Coach { Id = 7, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" },
                new Coach { Id = 8, FirstName = "Ali", LastName = "Kalu", Username = "AliKalu", Email = "Ali@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" },
                new Coach { Id = 9, FirstName = "Ahmed", LastName = "Kalu", Username = "AhmedKalu", Email = "Ahmed@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" }
             };

            _context.Coaches.AddRange(coaches);
            _context.SaveChanges();

        }
        [Fact]
        public async Task GetCoach_ReturnsCorrectType()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.GetCoaches();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Coach>>(objectResult.Value);

        }

        [Fact]
        public async Task GetCoach_ReturnsAllCoaches()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.GetCoaches();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var coaches = Assert.IsAssignableFrom<IEnumerable<Coach>>(objectResult.Value);
            Assert.Equal(4, coaches.Count());
        }

        [Fact]
        public async Task GetCoach_ReturnsNotFound_GivenInvalidId()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.GetCoach(50);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetCoach_ReturnsCoach_GivenvalidId()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.GetCoach(8);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var coach = Assert.IsAssignableFrom<Coach>(objectResult.Value);
            Assert.Equal("Ali", coach.FirstName);
        }


/*        [Fact]
        public async Task PostCoach_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new CoachesController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.CreateCoach(new Coach());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/

        [Fact]
        public async Task PostCoach_ReturnsNewlyCreatedCoach()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.CreateCoach(new Coach { Id = 15, FirstName = "Salm", LastName = "Kalu", Username = "SalmKalu", Email = "Salm@KAlu", Password = "Salm@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task PutCoach_ReturnsBadRequest_WhenCoachIdIsInvalid()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.UpdateCoach(100, new Coach { Id = 11, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

/*        [Fact]
        public async Task PutCoach_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new CoachesController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.UpdateCoach(7, new Coach { Id = 11 });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/


        [Fact]
        public async Task PutCoach_ReturnsNotFound_WhenCoachIdIsInvalid()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.UpdateCoach(52, new Coach { Id = 52, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutCoach_ReturnsNoContent_WhenCoachUpdated()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.UpdateCoach(7, new Coach { Id = 7, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCoach_ReturnsNotFound_WhenCoachIdIsInvalid()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.DeleteCoach(100);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteCoach_ReturnsOk_WhenCoachDeleted()
        {
            // Arange
            var controller = new CoachesController(_context);

            // Act
            var result = await controller.DeleteCoach(7);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}
