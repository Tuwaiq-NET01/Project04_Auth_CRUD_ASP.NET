using KittyCat.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyCatTest.Controllers
{
    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void Index_AreEqual()
        {
            //Arrange
            HomeController homeController = new HomeController();
            //Act
            ViewResult viewResult = homeController.Index() as ViewResult;
            //Assert
            Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}
