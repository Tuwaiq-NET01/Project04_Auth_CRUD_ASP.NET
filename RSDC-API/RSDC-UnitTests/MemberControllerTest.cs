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
    public class memberControllerTest : IDisposable
    {

        protected readonly RSDCContext _context;

        public memberControllerTest()
        {
            var options = new DbContextOptionsBuilder<RSDCContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RSDCContext(options);

            _context.Database.EnsureCreated();

            var members = new[]
            {
                new Member { Id = 7, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" },
                new Member { Id = 8, FirstName = "Ali", LastName = "Kalu", Username = "AliKalu", Email = "Ali@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" },
                new Member { Id = 9, FirstName = "Ahmed", LastName = "Kalu", Username = "AhmedKalu", Email = "Ahmed@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" }
             };

            _context.Members.AddRange(members);
            _context.SaveChanges();

        }
        [Fact]
        public async Task Getmember_ReturnsCorrectType()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.GetMembers();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Member>>(objectResult.Value);

        }

        [Fact]
        public async Task Getmember_ReturnsAllMembers()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.GetMembers();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var members = Assert.IsAssignableFrom<IEnumerable<Member>>(objectResult.Value);
            Assert.Equal(4, members.Count());
        }

        [Fact]
        public async Task Getmember_ReturnsNotFound_GivenInvalidId()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.GetMember(50);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Getmember_Returnsmember_GivenvalidId()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.GetMember(8);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var member = Assert.IsAssignableFrom<Member>(objectResult.Value);
            Assert.Equal("Ali", member.FirstName);
        }


/*        [Fact]
        public async Task Postmember_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new MembersController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.Createmember(new Member());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/

        [Fact]
        public async Task Postmember_ReturnsNewlyCreatedmember()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.CreateMember(new Member { Id = 15, FirstName = "Salm", LastName = "Kalu", Username = "SalmKalu", Email = "Salm@KAlu", Password = "Salm@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task Putmember_ReturnsBadRequest_WhenmemberIdIsInvalid()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.UpdateMember(100, new Member { Id = 11, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

/*        [Fact]
        public async Task Putmember_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arange
            var controller = new MembersController(_context);
            controller.ModelState.AddModelError("FirstName", "Required");
            // Act
            var result = await controller.Updatemember(7, new Member { Id = 11 });

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/


        [Fact]
        public async Task Putmember_ReturnsNotFound_WhenmemberIdIsInvalid()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.UpdateMember(52, new Member { Id = 52, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Putmember_ReturnsNoContent_WhenmemberUpdated()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.UpdateMember(7, new Member { Id = 7, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Deletemember_ReturnsNotFound_WhenmemberIdIsInvalid()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.DeleteMember(100);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Deletemember_ReturnsOk_WhenmemberDeleted()
        {
            // Arange
            var controller = new MembersController(_context);

            // Act
            var result = await controller.DeleteMember(7);

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
