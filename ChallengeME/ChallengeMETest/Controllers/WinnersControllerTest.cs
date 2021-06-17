using ChallengeME.Controllers;
using ChallengeME.Data;
using ChallengeME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMETest.Controllers
{
    class WinnersControllerTest
    {

        private ApplicationDbContext db;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            db = new ApplicationDbContext(options);

            db.Winners.Add(new Winner { Id = 1, wins = 2 , CommentId = 5});

            db.SaveChanges();

        }


        [Test]
        public void IndexViewReturnedCorrectly()
        {
            //Arrange
            WinnersController controller = new WinnersController(this.db);

            //Act
            ViewResult viewObj = (ViewResult)controller.Index();

            //Assert
            Assert.AreEqual("Index", viewObj.ViewName);
        }


        [Test]
        public void WinnerCreatedSuccessfully()
        {
            WinnersController controller = new WinnersController(this.db);
            var newWinner = new Winner() { Id = 2, wins = 10, CommentId = 6 };
            controller.CreateTest(6, newWinner);

            Assert.AreEqual(2, db.Winners.ToList().Count);
        }





    }
}
