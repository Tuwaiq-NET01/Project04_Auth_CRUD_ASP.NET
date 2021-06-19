using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Dtos;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FinalProjectTest.Controllers
{
    public class MoviesControllerTest
    {
        static DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "DummyDB").Options;
        // Temporary database for testing purposes
        static AppDbContext context = new AppDbContext (options);
        private static JwtService _jwtService = new JwtService();
        private MoviesController controller;
        
        [SetUp]
        public void Setup()
        {
            Movie movie = new Movie() { Id = 1, Date = "2021-12-22", Title = "IBRA", Rating = 10, Poster = "asdf"};
            context.Add(movie);
            context.SaveChanges();
            controller = new MoviesController(context, _jwtService);
            
        }

        [Test]
        public void GetTest()
        {
            var result = (OkObjectResult) controller.Get(1);
            var m = (Movie)result.Value;
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.IsAssignableFrom<Movie>(result.Value);
            Assert.AreEqual("IBRA", m.Title);
        }
    }
}