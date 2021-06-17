using Coffee.Controllers;
using Coffee.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTest.Controllers
{
    [TestFixture]
    class RecommendationsControllerTest
    {
        [Test]
        public void Create_Test()
        {
            //Arrange
            RecommendationsController RecommendationController = new RecommendationsController(null);

            //Act
            ViewResult viewResult = RecommendationController.Create() as ViewResult;

            //Assert
            Assert.IsNull(viewResult.ViewName);
        }

        [Test]
        public void Index_Test()
        {
            //Arrange
            RecommendationsController RecommendationController = new RecommendationsController();

            //Act
            ViewResult viewResult = RecommendationController.Index2() as ViewResult;

            //Assert
            NUnit.Framework.Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}
