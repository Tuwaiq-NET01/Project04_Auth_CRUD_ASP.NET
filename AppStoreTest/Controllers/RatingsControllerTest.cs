using AppStore.Controllers;
using AppStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUnit.Framework;

namespace AppStoreTest.Controllers
{
    public class RatingsControllerTest
    {
        private RatingsController _ratingsController;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AppStore").Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted();
            _ratingsController = new RatingsController(_context,_userManager);
        }

        [Test]
        public void User_Create_Rating_For_App_Return_ViewResult()
        {
            RatingsController ratingsController = new RatingsController(_context,_userManager);

            var result = ratingsController.Create(1,"09a7167c22-83f2-4438-aae8-ded96824c67e");

            Assert.IsTrue(result is ViewResult);
            Assert.Pass();
        }
    }
}