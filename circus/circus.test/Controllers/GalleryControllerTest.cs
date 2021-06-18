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
    class GalleryControllerTest 
    {
        private GalleryController gc;
        [SetUp]
        public void Setup()
        {
            var opt = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Tcircus").Options;
            var context = new ApplicationDbContext(opt);
            context.Database.EnsureDeleted();
            gc = new GalleryController(context);
            seed(context);
        }
        public void seed(ApplicationDbContext context)
        {
            var venues = new[]
            {
                new VenueModel() {Id=1, Address="ad1", Image="img1", Type="venue1", Name="n1"},
                new VenueModel() {Id=2, Address="ad2", Image="img2", Type="venue2", Name="n2"}
            };
            var performers = new[]
      {
                new PerformerModel() {Id=1, Image="img1", Profession="prof1", Name="n1"},
                new PerformerModel() {Id=2, Image="img2", Profession="prof2", Name="n2"}
            };
            context.Venues.AddRange(venues);
            context.Performers.AddRange(performers);
            context.SaveChanges();
        }
        [Test]
        public void indexTest_NullPageView()
        {
            ViewResult result = gc.Index() as ViewResult;
            Assert.IsNull(result.ViewName);
        }
        [Test]
        public void indexTest_NotNullPageView()
        {
            var gal = gc.Index();
            ViewResult result = gal as ViewResult;
            Assert.IsNull(result.ViewName);
        }
    }
}
