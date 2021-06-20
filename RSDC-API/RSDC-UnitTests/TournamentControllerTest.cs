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
    public class TournamentControllerTest : IDisposable
    {

        protected readonly RSDCContext _context;

        public TournamentControllerTest()
        {
            var options = new DbContextOptionsBuilder<RSDCContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RSDCContext(options);

            _context.Database.EnsureCreated();

            var tournaments = new[]
            {
                new Tournament { Id = 7, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 },
                new Tournament { Id = 8, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 },
                new Tournament { Id = 9, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 }
               
            };

            _context.Tournaments.AddRange(tournaments);
            _context.SaveChanges();

        }
        [Fact]
        public async Task GetTournament_ReturnsCorrectType()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.GetTournaments();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Tournament>>(objectResult.Value);

        }

        [Fact]
        public async Task GetTournament_ReturnsAllTournaments()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.GetTournaments();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var tournaments = Assert.IsAssignableFrom<IEnumerable<Tournament>>(objectResult.Value);
            Assert.Equal(4, tournaments.Count());
        }

        [Fact]
        public async Task GetTournament_ReturnsNotFound_GivenInvalidId()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.GetTournament(50);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetTournament_ReturnsTournament_GivenvalidId()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.GetTournament(8);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var tournament = Assert.IsAssignableFrom<Tournament>(objectResult.Value);
            Assert.Equal("Swimming", tournament.TourType);
        }


/*        [Fact]
        public async Task PostTournament_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new TournamentsController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.CreateTournament(new Tournament());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/

        [Fact]
        public async Task PostTournament_ReturnsNewlyCreatedTournament()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.CreateTournament(new Tournament { Id = 15, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 });

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task PutTournament_ReturnsBadRequest_WhenTournamentIdIsInvalid()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.UpdateTournament(100, new Tournament { Id = 11, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 });

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

/*        [Fact]
        public async Task PutTournament_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new TournamentsController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.UpdateTournament(7, new Tournament { Id = 11 });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/


        [Fact]
        public async Task PutTournament_ReturnsNotFound_WhenTournamentIdIsInvalid()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.UpdateTournament(52, new Tournament { Id = 52, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 });

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutTournament_ReturnsNoContent_WhenTournamentUpdated()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.UpdateTournament(7, new Tournament { Id = 7, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 });

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTournament_ReturnsNotFound_WhenTournamentIdIsInvalid()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.DeleteTournament(100);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteTournament_ReturnsOk_WhenTournamentDeleted()
        {
            // Arange
            var controller = new TournamentsController(_context);

            // Act
            var result = await controller.DeleteTournament(7);

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
