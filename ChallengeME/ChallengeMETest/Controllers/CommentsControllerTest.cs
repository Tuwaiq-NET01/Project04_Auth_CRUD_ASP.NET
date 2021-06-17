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
    class CommentsControllerTest
    {



        private ApplicationDbContext db;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            db = new ApplicationDbContext(options);

            db.Comments.Add(new Comment { Id = 1, Title = "this is a comment1 ", ChallengeId = 1, isWinner = false , Time = DateTime.Now });
            db.Comments.Add(new Comment { Id = 2, Title = "this is a comment2 ", ChallengeId = 2, isWinner = false , Time = DateTime.Now });

            db.SaveChanges();

        }


        [Test]
        public void IndexViewReturnedCorrectly()
        {
            //Arrange
            CommentsController controller = new CommentsController(this.db);

            //Act
            ViewResult viewObj = (ViewResult)controller.Index();

            //Assert
            Assert.AreEqual("Index", viewObj.ViewName);
        }


        [Test]
        public void CommentDeletedSuccessfully()
        {
            //Arrange
            CommentsController controller = new CommentsController(this.db);

            //Act
            var res = (Comment)controller.DeleteTest(1);

            //Assert
            Assert.IsNull(db.Comments.ToList().Find(x => x.Id == 1));
        }



    }
}
