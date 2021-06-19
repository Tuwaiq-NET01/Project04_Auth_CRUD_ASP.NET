using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FinalProjectTest.Controllers
{
    public class SearchControllerTest
    {
        static DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "DummyDB").Options;
        // Temporary database for testing purposes
        static AppDbContext context = new AppDbContext (options);
        private static JwtService _jwtService = new JwtService();
        private SearchController controller;
        
        [SetUp]
        public void Setup()
        {
            controller = new SearchController(context, _jwtService);
        }

        [Test]
        public void GetTest()
        {
            var result = (UnauthorizedResult) controller.GetMovie("IBRA");
            Assert.IsInstanceOf<UnauthorizedResult>(result);
        }
    }
}