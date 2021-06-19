using System.Collections.Generic;
using System.Linq;
using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FinalProjectTest.Controllers
{
    public class AuthControllerTest
    {
        // static DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "DummyDB").Options;
        // // Temporary database for testing purposes
        // static AppDbContext context = new AppDbContext (options);
        // private static JwtService _jwtService = new JwtService();
        // private MoviesController controller;
        //
        // [SetUp]
        // public void Setup()
        // {
        //     Movie movie = new Movie() { Id = 1, Date = "2021-12-22", Title = "IBRA", Rating = 10, Poster = "asdf"};
        //     context.Add(movie);
        //     context.SaveChanges();
        //     controller = new MoviesController(context, _jwtService);
        // }
        //
        // [Test]
        // public void GetTest()
        // {
        //     var result = (OkObjectResult)controller.Get(1);
        //     
        //     Assert.IsInstanceOf<OkObjectResult>(result);
        //     Assert.IsAssignableFrom<Movie>(result.Value);
        //     // Assert.AreEqual(1, result.Formatters.Count);
        //     // Assert.AreEqual(new OkObjectResult(movie), );
        // }
    }
}