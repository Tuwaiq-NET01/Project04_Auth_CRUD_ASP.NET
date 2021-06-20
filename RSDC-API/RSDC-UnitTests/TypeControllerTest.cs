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
using Type = RSDC_API.Type;

namespace RSDC_UnitTests
{
    public class TypeControllerTest : IDisposable
    {

        protected readonly RSDCContext _context;

        public TypeControllerTest()
        {
            var options = new DbContextOptionsBuilder<RSDCContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RSDCContext(options);

            _context.Database.EnsureCreated();

            var types = new[]
            {
                new Type { Id = 7, Fee = 2000, DivingType = "Deep" },
                new Type { Id = 8, Fee = 3000, DivingType = "Deep" },
                new Type { Id = 9, Fee = 3000, DivingType = "Deep" }
             };

            _context.Types.AddRange(types);
            _context.SaveChanges();

        }
        [Fact]
        public async Task GetType_ReturnsCorrectType()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.GetTypes();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Type>>(objectResult.Value);

        }

        [Fact]
        public async Task GetType_ReturnsAllTypes()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.GetTypes();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var types = Assert.IsAssignableFrom<IEnumerable<Type>>(objectResult.Value);
            Assert.Equal(6, types.Count());
        }

        [Fact]
        public async Task GetType_ReturnsNotFound_GivenInvalidId()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.GetType(50);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetType_ReturnsType_GivenvalidId()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.GetType(8);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var type = Assert.IsAssignableFrom<Type>(objectResult.Value);
            Assert.Equal("Deep", type.DivingType);
        }


/*        [Fact]
        public async Task PostType_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new TypesController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.CreateType(new Type());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/

        [Fact]
        public async Task PostType_ReturnsNewlyCreatedType()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.CreateType(new Type { Id = 15, Fee = 2500, DivingType = "Deep" });

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task PutType_ReturnsBadRequest_WhenTypeIdIsInvalid()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.UpdateType(100, new Type { Id = 11, Fee = 1500, DivingType = "Deep"});

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

/*        [Fact]
        public async Task PutType_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new TypesController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.UpdateType(7, new Type { Id = 11 });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/


        [Fact]
        public async Task PutType_ReturnsNotFound_WhenTypeIdIsInvalid()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.UpdateType(52, new Type { Id = 52, Fee = 2000, DivingType = "Deep" });

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutType_ReturnsNoContent_WhenTypeUpdated()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.UpdateType(7, new Type { Id = 7, Fee = 200, DivingType = "Deep"});

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteType_ReturnsNotFound_WhenTypeIdIsInvalid()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.DeleteType(100);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteType_ReturnsOk_WhenTypeDeleted()
        {
            // Arange
            var controller = new TypesController(_context);

            // Act
            var result = await controller.DeleteType(7);

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
