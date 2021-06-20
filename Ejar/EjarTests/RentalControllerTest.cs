using Ejar.Controllers;
using Ejar.Data;
using Ejar.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EjarTests
{
    public class RentalControllerTest
    {
          private ApplicationDbContext _db;
        
                [SetUp]
                public void Setup()
                {
                    // in memeory database
                    var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Ejar")
                        .Options;
                    this._db = new ApplicationDbContext(options);
                    var context = new ApplicationDbContext(options);
        
                }
        
                [Test]
                public void Test_getDays() //this method returns the difference between two given dates 
                {
                    //Arrange
                    RentalController rentalController = new RentalController(_db);
                    string date1 = "2020-01-01";
                    string date2 = "2020-01-11";

                    //Act
                    var Expected_Value = 10;
                    var Actual_Value = rentalController.getDays(date1, date2);
        
                    //Assert
                    Assert.AreEqual(Expected_Value, Actual_Value);
        
                }
        
                public void SeedUsers()
                {
                    var User1 = new ApplicationUser
                    {
                        Id = 5, UserName = "user1", Account = new AccountModel(),
                        Email = "user1@test.com"
                    };
                    User1.Account.FirstName = "Ahmed";
                    User1.Account.LastName = "Ali";
                    User1.Account.PhoneNumber = 012345678;
        
                    var User2 = new ApplicationUser()
                    {
                        Id = 6, UserName = "user2", Account = new AccountModel(),
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
    }
}