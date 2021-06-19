using System;
using System.Collections.Generic;
using AppStore.Data;
using AppStore.Models;
using AppStore.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUnit.Framework;

namespace AppStoreTest.Controllers
{
    public class AppsControllerTest
    {
        private AppsController _appsController;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AppStore").Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted();
            _appsController = new AppsController(_context);
            SeedApps(_context);
        }


        [Test]
        public void Search_For_Whatsapp_App_Returns_View_Index()
        {
            AppsController appsController = new AppsController(_context);

            var result = appsController.Search("Whatsapp");

            Assert.IsTrue(result is ViewResult);
            Assert.Pass();
        }

        [Test]
        public void Search_For_Fake_App_Returns_View_Index()
        {
            AppsController appsController = new AppsController(_context);

            var result = appsController.Search("Not Real App");

            Assert.IsTrue(result is ViewResult);
            Assert.Pass();
        }

        [Test]
        public void Search_With_Empty_String_Returns_RedirectToAction_Index()
        {
            AppsController appsController = new AppsController(_context);

            var result = appsController.Search("");

            Assert.IsTrue(result is RedirectToActionResult);
            Assert.Pass();
        }


        public void SeedApps(ApplicationDbContext context)
        {
            
            var app1 = new AppModel()
            {
                Id = 1, Name = "Twitter", Description = "Tweets App", GeneralCategory = "Social Media",
                DownloadsCount = 0,
                Icon =
                    "https://png.pngtree.com/png-clipart/20190613/original/pngtree-twitter-icon-png-image_3584901.jpg",
                Size = "40MB",
                AverageRating = 0
            };
            var app2 = new AppModel()
                {
                    Id = 2, Name = "Chess", Description = "Chess Game", GeneralCategory = "Games",
                    DownloadsCount = 0,
                    Icon = "https://media.istockphoto.com/vectors/chess-icon-on-white-background-vector-id931757036",
                    Size = "20MB",
                    AverageRating = 0
                }
                ;
            var user = new ApplicationUser()
            {
                Id = "09a7167c22-83f2-4438-aae8-ded96824c67e",
                Name = "Abdullah",
                Email = "example@gmail.com"
            };

            var Rating1 = new RatingModel()
            {
                Id = 1, Rating = 3, Review = "test", AppId = 1, UserId = "09a7167c22-83f2-4438-aae8-ded96824c67e",
                ReviewDate = DateTime.Now,App = app1, User = user
            };
            var Rating2 = new RatingModel()
            {
                Id = 2, Rating = 4, Review = "test2", AppId = 2, UserId = "09a7167c22-83f2-4438-aae8-ded96824c67e",
                ReviewDate = DateTime.Now,App = app2, User = user
            };

            var Download1 = new DownloadModel()
            {
                Id = 1, AppId = 1, DownloadDate = DateTime.Now, UserId = "09a7167c22-83f2-4438-aae8-ded96824c67e",
                App = app1, User = user
            };
            var Download2 = new DownloadModel()
            {
                Id = 2, AppId = 2, DownloadDate = DateTime.Now, UserId = "09a7167c22-83f2-4438-aae8-ded96824c67e",
                App = app2, User = user
            };

            context.Apps.AddRange(app1, app2);
            context.Users.Add(user);
            context.Ratings.AddRange(Rating1, Rating2);
            context.Downloads.AddRange(Download1, Download2);
            context.SaveChanges();
        }
    }
}