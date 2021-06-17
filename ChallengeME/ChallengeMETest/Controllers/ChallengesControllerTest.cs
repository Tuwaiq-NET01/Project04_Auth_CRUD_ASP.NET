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
    [TestFixture]
    public class ChallengesControllerTest
    {


        private ApplicationDbContext db;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            db = new ApplicationDbContext(options);

            db.Challenges.Add(new Challenge { Id = 1 , Title = "Challenge 1", GameId = 1 });
            db.Challenges.Add(new Challenge { Id = 2 , Title = "Challenge 2", GameId = 1 });
            db.Challenges.Add(new Challenge { Id = 3 , Title = "Challenge 3", GameId = 2 });
            db.Challenges.Add(new Challenge { Id = 4 , Title = "Challenge 4", GameId = 3 });

            db.SaveChanges();

        }



        [Test]
        public void IndexViewReturnedCorrectly()
        {
            //Arrange
            ChallengesController controller = new ChallengesController(this.db);

            //Act
            ViewResult viewObj = (ViewResult)controller.Index();

            //Assert
            Assert.AreEqual("Index", viewObj.ViewName);
        }


        [Test]
        public void CreateViewReturnedCorrectly()
        {
            //Arrange
            ChallengesController controller = new ChallengesController(this.db);

            //Act
            ViewResult viewObj = (ViewResult)controller.Create(1);

            //Assert
            Assert.AreEqual("Create", viewObj.ViewName);
        }

        [Test]
        public void SuccessfullyGettingTheDifficulties()
        {
            //Arrange
            ChallengesController controller = new ChallengesController(this.db);

            //Act
            var Diff_List = (List<string>)controller.getDiff();

            List<string> expected = new List<string>() { "Easy", "Normal", "Hard" };

            //Assert
            Assert.AreEqual(Diff_List, expected);

        }

        [Test]
        public void ChallengeEditedSuccessfully()
        {
            ChallengesController controller = new ChallengesController(this.db);

            var original_challenge = db.Challenges.ToList().Find(x => x.Id == 2);
            var changed_challenge = new Challenge() { Id = 2, Title = "Challenge 2 edited", GameId = 1 };

            //Act
            var res = (Challenge)controller.EditTest(2, changed_challenge);

            //Assert
            Assert.AreEqual(original_challenge, res);
        }




    }
}
