using circus.Controllers;
using circus.Data;
using circus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace circus.test.Controllers
{
    [TestFixture]
    class TicketsControllerTest
    {
        private TicketsController tc;
        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Tcircus").Options;
            var context = new ApplicationDbContext(opt);
            context.Database.EnsureDeleted();
            tc = new TicketsController(context);
            seed(context);
        }
        public void seed(ApplicationDbContext context)
        {
            var shows = new[]
            {
               new ShowModel(){Id = 1, Date = new DateTime(), PerformerId = 1, VenueId = 1},
               new ShowModel(){Id = 2, Date = new DateTime(), PerformerId = 2, VenueId = 2}
           };
            var performers = new[]
            {
                new PerformerModel() {Id=1, Image="img1", Profession="prof1", Name="n1"},
                new PerformerModel() {Id=2, Image="img2", Profession="prof2", Name="n2"}
            };
            var tickets = new[]
            {
                new TicketModel(){Id= 1, Quantity= 2, ShowId = 1, UserId = "1"},
                new TicketModel(){Id= 2, Quantity= 4, ShowId = 2, UserId = "2"}
            };
            context.Shows.AddRange(shows);
            context.Performers.AddRange(performers);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
        [Test]
        public void indexTest_UserIsAuthenticated()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "Hello"),
                                        new Claim(ClaimTypes.Name, "hi@example.com")
                                        // other required and custom claims
                                   }, "TestAuthentication"));
            var controller = tc;
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var result = controller.Index() as ViewResult;
            var viewName = result.ViewName;
            Assert.True(string.IsNullOrEmpty(viewName) || viewName == "Index");
        }
        [Test]
        public void indexTest_RedirectToUnauthenticatedUser()
        {
            var controller = tc;
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = null };
            var result = tc.Index() as RedirectResult;
            Assert.That(result.Url.Equals("~/Identity/Account/Login"));
        
        }
    }
}
