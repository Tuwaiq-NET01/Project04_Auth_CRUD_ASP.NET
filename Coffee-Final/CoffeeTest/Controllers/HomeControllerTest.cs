using Coffee.Controllers;
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
    class HomeControllerTest
    {

        [Test]
        public void Index_Home_AreEqual()
        {
            //Arrange
            HomeController HomeController = new HomeController();

            //Act
            ViewResult viewResult = HomeController.Index() as ViewResult;

            //Assert
            Assert.AreEqual(null, viewResult.ViewName);
        }
    }

}
