using circus.Controllers;
using circus.Data;
using circus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var users = new[]
            {
                new IdentityUser(){Id = "1"},
                new IdentityUser(){Id="2"}
            };
            context.Shows.AddRange(shows);
            context.Users.AddRange(users);
            context.Performers.AddRange(performers);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
        [Test]
        public void indexTest_NullPageView()
        {
            ViewResult result = tc.Index() as ViewResult;
            Assert.IsNull(result.ViewName);
        }
        [Test]
        public void indexTest_NotNullPageView()
        {
            IdentityUser user = new IdentityUser();
           
            var ticket = tc.Index();
            ViewResult result = ticket as ViewResult;
           // Assert.IsTrue(user.Id == "1");
        }
     
    }
}
