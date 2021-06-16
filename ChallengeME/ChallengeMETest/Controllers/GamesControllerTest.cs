using ChallengeME.Controllers;
using ChallengeME.Data;
using ChallengeME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeMETest.Controllers
{
    public class GamesControllerTest
    {

        private ApplicationDbContext db;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            db = new ApplicationDbContext(options);

            db.Games.Add(new Game { Id = 1, GameName = "game1" , User_Id = "user1"});
            db.Games.Add(new Game { Id = 2, GameName = "game2" , User_Id = "user2"});

            db.SaveChanges();

        }



        [Test]
        public void IndexViewReturnedCorrectly()
        {
            //Arrange
            GamesController controller = new GamesController(this.db);

            //Act
            ViewResult viewObj = (ViewResult)controller.Index();

            //Assert
            Assert.AreEqual("Index", viewObj.ViewName);
        }


        [Test]
        public void Return404ifNotFound()
        {
            GamesController controller = new GamesController(this.db);

            ViewResult viewObj = (ViewResult)controller.Details(999);

            Assert.AreEqual("fof", viewObj.ViewName);
        }




        [Test]
        public void RedirectAfterCreatingGameSuccessfully()
        {
            GamesController controller = new GamesController(this.db);
            string current_user = "user4";
            Game new_game = new Game() { Id = 5, GameName = "creatingGame", GameImage = "test", User_Id = current_user };
            var viewObj = (RedirectToActionResult)controller.CreateTest(new_game, current_user);

            Assert.AreEqual(viewObj.ActionName , "Index");

        }



        [Test]
        public void userNotLoggedIn_SoItWillFail()
        {
            GamesController controller = new GamesController(this.db);
            //not logged in
            string current_user = null; 
            Game new_game = new Game() { Id = 5, GameName = "creatingGame", GameImage = "test", User_Id = current_user };
            var viewObj = (ContentResult)controller.CreateTest(new_game, current_user);

            Assert.AreEqual(viewObj.Content, "NOT FOUND!");
        }




    }
}
