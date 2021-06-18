using HealthChoice_Proj4.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChoice_Proj4Test.Controllers
{
    [TestFixture]
    class CommentsControllerTest
    {
        [Test]
        public void Index_AreEqual()
        {
            //Arrange
            CommentsController commentsController = new CommentsController();
            //Act
            ViewResult viewResult = commentsController.Index() as ViewResult;
            //Assert
            Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}
