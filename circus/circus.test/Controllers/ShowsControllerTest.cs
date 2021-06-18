using circus.Controllers;
using circus.Data;
using circus.Models;
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
    class ShowsControllerTest
    {
        private ShowsController sc;
        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Tcircus").Options;
            var context = new ApplicationDbContext(opt);
            context.Database.EnsureDeleted();
            sc = new ShowsController(context);
            seed(context);
        }
        public void seed(ApplicationDbContext context)
        {
            var shows = new[]
            {
               new ShowModel(){Id = 1, Date = new DateTime(), PerformerId = 1, VenueId = 1},
               new ShowModel(){Id = 2, Date = new DateTime(), PerformerId = 2, VenueId = 2}
           };
            context.Shows.AddRange(shows);
            context.SaveChanges();
        }
        [Test]
        public void indexTest_NullPageView()
        {
            ViewResult result = sc.Index() as ViewResult;
            Assert.IsNull(result.ViewName);
        }
        [Test]
        public void indexTest_NotNullPageView()
        {
            var show = sc.Index();
            ViewResult result = show as ViewResult;
            Assert.IsNull(result.ViewName);
        }
      
    }
}
