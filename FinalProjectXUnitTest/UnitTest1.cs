using System;
using System.Collections.Generic;
using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinalProjectXUnitTest
{
    public class UnitTest1
    {
        static DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "DummyDB").Options;
        // Temporary database for testing purposes
        static AppDbContext context = new AppDbContext (options);
        private static JwtService _jwtService = new JwtService();
        private MoviesController controller;
        
        [Fact]
        public void Test1()
        {
            // Arrange
            Movie movie = new Movie() { Id = 1, Date = "2021-12-22", Title = "IBRA", Rating = 10, Poster = "asdf"};
            context.Add(movie);
            context.SaveChanges();
            controller = new MoviesController(context, _jwtService);
            
            // Act
            var result = controller.Get(1);
            
            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var m = Assert.IsAssignableFrom<Movie>(objectResult.Value);
            Assert.Equal("IBRA",m.Title);
        }
    }
}