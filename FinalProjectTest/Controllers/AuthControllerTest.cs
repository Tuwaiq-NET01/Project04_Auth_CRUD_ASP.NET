using System.Collections.Generic;
using System.Linq;
using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Dtos;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FinalProjectTest.Controllers
{
    public class AuthControllerTest
    {
        static DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "DummyDB").Options;
        // Temporary database for testing purposes
        static AppDbContext context = new AppDbContext (options);
        private static JwtService _jwtService = new JwtService();
        private AuthController controller;
        
        [SetUp]
        public void Setup()
        {
            controller = new AuthController(context, _jwtService);
        }

        [Test]
        public void RegisterTest()
        {
            RegisterDto user = new RegisterDto() { Name = "IBRA", Email = "ibra@ibra", Password = "123"};
            
            var result = (CreatedResult) controller.Register(user);
            var m = (User)result.Value;
            Assert.IsInstanceOf<CreatedResult>(result);
            Assert.IsAssignableFrom<User>(result.Value);
            Assert.AreEqual("IBRA", m.Name);
        }
    }
}