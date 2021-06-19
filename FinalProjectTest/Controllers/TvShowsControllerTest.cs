using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FinalProjectTest.Controllers
{
    public class TvShowsControllerTest
    {
        static DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "DummyDB").Options;
        // Temporary database for testing purposes
        static AppDbContext context = new AppDbContext (options);
        private static JwtService _jwtService = new JwtService();
        private TvShowsController controller;
        
        [SetUp]
        public void Setup()
        {
            TvShow tvShow = new TvShow() { Id = 1, Date = "2021-12-22", Title = "IBRA", Rating = 10, Poster = "asdf"};
            context.Add(tvShow);
            context.SaveChanges();
            controller = new TvShowsController(context, _jwtService);
            
        }

        [Test]
        public void GetTest()
        {
            var result = (OkObjectResult) controller.Get(1);
            var m = (TvShow)result.Value;
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsAssignableFrom<TvShow>(result.Value);
            Assert.AreEqual("IBRA", m.Title);
        }
    }
}