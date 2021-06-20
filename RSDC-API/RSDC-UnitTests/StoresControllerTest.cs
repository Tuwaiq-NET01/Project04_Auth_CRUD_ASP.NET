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
    public class StoreControllerTest : IDisposable
    {

        protected readonly RSDCContext _context;

        public StoreControllerTest()
        {
            var options = new DbContextOptionsBuilder<RSDCContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RSDCContext(options);

            _context.Database.EnsureCreated();

            var stores = new[]
            {
                new Store { Id = 6, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 45.50, TypeId = 1 },
                new Store { Id = 7, Title = "Suit", Image = "https://www.scubastore.com/l/13737/137371573/aqualung-fusion-bullet-air.jpg", Description = "Aqualung Fusion Bullet Air", Price = 4500.50, TypeId = 1 },
                new Store { Id = 8, Title = "Suit", Image = "https://www.scubastore.com/f/13796/137963780/typhoon-quantum-lady.jpg", Description = "Typhoon Quantum Lady", Price = 4000, TypeId = 2 },
                new Store { Id = 9, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 40.50, TypeId = 2 }
            };

            _context.Stores.AddRange(stores);
            _context.SaveChanges();

        }
        [Fact]
        public async Task GetStore_ReturnsCorrectType()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.GetStores();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Store>>(objectResult.Value);

        }

        [Fact]
        public async Task GetStore_ReturnsAllStorees()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.GetStores();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var stores = Assert.IsAssignableFrom<IEnumerable<Store>>(objectResult.Value);
            Assert.Equal(8, stores.Count());
        }

        [Fact]
        public async Task GetStore_ReturnsNotFound_GivenInvalidId()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.GetStore(50);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetStore_ReturnsStore_GivenvalidId()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.GetStore(8);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var store = Assert.IsAssignableFrom<Store>(objectResult.Value);
            Assert.Equal("Suit", store.Title);
        }


/*        [Fact]
        public async Task PostStore_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new StoreesController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.CreateStore(new Store());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/

        [Fact]
        public async Task PostStore_ReturnsNewlyCreatedStore()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.CreateStore(new Store { Id = 15, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 45.50, TypeId = 1 });

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task PutStore_ReturnsBadRequest_WhenStoreIdIsInvalid()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.UpdateStore(100, new Store { Id = 11, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 45.50, TypeId = 1 });

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

/*        [Fact]
        public async Task PutStore_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new StoreesController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.UpdateStore(7, new Store { Id = 11 });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/


        [Fact]
        public async Task PutStore_ReturnsNotFound_WhenStoreIdIsInvalid()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.UpdateStore(52, new Store { Id = 52, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 45.50, TypeId = 1 });

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutStore_ReturnsNoContent_WhenStoreUpdated()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.UpdateStore(7, new Store { Id = 7, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 45.50, TypeId = 1 });

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteStore_ReturnsNotFound_WhenStoreIdIsInvalid()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.DeleteStore(100);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteStore_ReturnsOk_WhenStoreDeleted()
        {
            // Arange
            var controller = new StoresController(_context);

            // Act
            var result = await controller.DeleteStore(7);

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
