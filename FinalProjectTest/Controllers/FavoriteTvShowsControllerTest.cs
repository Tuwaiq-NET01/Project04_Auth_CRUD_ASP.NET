using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FinalProjectTest.Controllers
{
    public class FavoriteTvShowsControllerTest
    {
        static DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "DummyDB").Options;
        // Temporary database for testing purposes
        static AppDbContext context = new AppDbContext (options);
        private static JwtService _jwtService = new JwtService();
        private FavoriteTvShowsController controller;
        
        [SetUp]
        public void Setup()
        {
           
            controller = new FavoriteTvShowsController(context, _jwtService);
            
        }

        [Test]
        public void GetFavMovieTest()
        {
            var result = (UnauthorizedResult) controller.GetFavTvShow();
            // var m = (TvShow)result.Value;
            Assert.IsInstanceOf<UnauthorizedResult>(result);
            // Assert.IsAssignableFrom<TvShow>(result.Value);
            // Assert.AreEqual("IBRA", m.Title);
        }
    }
}