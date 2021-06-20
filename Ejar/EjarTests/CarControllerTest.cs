using Ejar.Controllers;
using Ejar.Data;
using Ejar.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EjarTests
{
    public class Test
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
                    
                    SeedUsers();
                    SeedCars();
                }
        
                [Test]
                public void Test_getCar() //this method takes a car id and return the car 
                {
                    //Arrange
                    CarController carController = new CarController(_db);
                    CarModel car = carController.getCar(1);
                    
                    //Act
                    var Expected_carName = "Camry";
                    var Actual_FirstName = car.CarName;
                    
                    //Assert
                    Assert.AreEqual(Expected_carName, Actual_FirstName);
                    
                    //Arange
                    car = carController.getCar(2);
                    
                    //Act
                    Expected_carName = "Lexus";
                    Actual_FirstName = car.CarName;
                    
                    //Assert
                    Assert.AreEqual(Expected_carName, Actual_FirstName);
                }
                
                // seeding methods
                public void SeedUsers()
                {
                    var User1 = new ApplicationUser
                    {
                        Id = 1, UserName = "user1", Account = new AccountModel(),
                        Email = "user1@test.com"
                    };
                    User1.Account.FirstName = "Ahmed";
                    User1.Account.LastName = "Ali";
                    User1.Account.PhoneNumber = 012345678;
        
                    var User2 = new ApplicationUser()
                    {
                        Id = 2, UserName = "user2", Account = new AccountModel(),
                        Email = "user2@test.com"
                    };
                    User2.Account.FirstName = "Fahad";
                    User2.Account.LastName = "Raid";
                    User2.Account.PhoneNumber = 876543210;
        
                    _db.Account.Add(User1.Account);
                    _db.Account.Add(User2.Account);
                    _db.Users.Add(User1);
                    _db.Users.Add(User2);
                    _db.SaveChanges();
                }
                
                public void SeedCars()
                {
                    var Car1 = new CarModel()
                    {
                        Id = 1 , CarName = "Camry", Manufacturer = "Toyota", Type = "Gas", 
                        Year = 2020, DayPrice = 120m, HourPrice  = 12m, UserId = 1
                    };
        
                    var Car2 = new CarModel()
                    {
                        Id = 2 , CarName = "Lexus", Manufacturer = "Toyota", Type = "Gas", 
                        Year = 2019, DayPrice = 140m, HourPrice  = 19m, UserId = 2 
                    };
                    _db.Car.Add(Car1);
                    _db.Car.Add(Car2);
                    _db.SaveChanges();
                }
                
                public void SeedTrips(){
                    var Trip1 = new TripModel()
                    {
                        Id = 1, UserId = 1, CarId = 2, DateReservedFrom = "2021-09-09", DateReservedUntil = "2021-10-09"
                    };
        
                    var Trip2 = new TripModel()
                    {
                        Id = 2, UserId = 2, CarId = 1, DateReservedFrom = "2021-07-09", DateReservedUntil = "2021-09-09"
                    };
                    
                    _db.Trip.Add(Trip1);
                    _db.Trip.Add(Trip2);
                    _db.SaveChanges();
                }
    }
}