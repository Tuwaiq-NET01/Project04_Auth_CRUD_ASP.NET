using ChallengeME.Controllers;
using ChallengeME.Data;
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


    }
}
