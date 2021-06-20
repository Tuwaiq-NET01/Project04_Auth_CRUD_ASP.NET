using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using mininet.Data;
using mininet.Controllers;
using System.Threading.Tasks;
using mininet.Models;
namespace mininetests.Controllers
{
    public class FeedsControllerTest
    {
        private FeedsController _feed;
        private UserManager<AppUser> _userManager;
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MiniTest").Options;
            var _db = new ApplicationDbContext(options);
            _db.Database.EnsureDeleted();
            _feed = new FeedsController(_db, _userManager);
            seeding(_db);
        }
        [Test]
        public void Test_Delete_Valid_Input()
        {
            var result = _feed.DeleteTest(1) as RedirectToActionResult;
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public void Test_Delete_inValid_Input()
        {
            var result = _feed.DeleteTest(null) as ViewResult;
            Assert.AreEqual("_NotFound", result.ViewName);
        }

        public void seeding(ApplicationDbContext _db)
        {
            RssFeedModel[] rssFeeds = new[]
            {
                new RssFeedModel { Id = 1, Title = "test Note", Description = "Bla Bla"}
            };
            _db.rssFeeds.AddRange(
                rssFeeds
            );
            _db.SaveChanges();
        }
    }
}