using System.Collections.Generic;
using Ejar.Controllers;
using Ejar.Data;
using Ejar.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EjarTests
{
    public class HomeControllerTest
    {
        private ApplicationDbContext _db;
                
        [SetUp]
        public void Setup()
        {
            // in memeory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Ejar").Options;
            this._db = new ApplicationDbContext(options);
            var context = new ApplicationDbContext(options);
            
            // seed the database
            SeedCars();
        }

        [Test]
        public void Test_getAllCars() //this method returns all cars car 
        {
            //Arrange
            HomeController homeController = new HomeController(_db);
            List<CarModel> cars = homeController.getAllCars();
            //Act
            var Expected_Number_of_cars = 2;
            var Actual_Number_of_cars = cars.Count;

            //Assert
            Assert.AreEqual(Expected_Number_of_cars, Actual_Number_of_cars);

        }
        

        public void SeedCars()
        {
            var Car1 = new CarModel()
            {
                Id = 3 , CarName = "Camry", Manufacturer = "Toyota", Type = "Gas", 
                Year = 2020, DayPrice = 120m, HourPrice  = 12m, UserId = 1
            };

            var Car2 = new CarModel()
            {
                Id = 4 , CarName = "Lexus", Manufacturer = "Toyota", Type = "Gas", 
                Year = 2019, DayPrice = 140m, HourPrice  = 19m, UserId = 2 
            };
            _db.Car.Add(Car1);
            _db.Car.Add(Car2);
            _db.SaveChanges();
        }
    }
}