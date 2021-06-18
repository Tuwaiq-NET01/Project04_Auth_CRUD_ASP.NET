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
    class AdopterControllerTest
    {
        [Test]
        public void Index_AreEqual()
        {
            //Arrange
            AdopterController homeController = new AdopterController();
            //Act
            ViewResult viewResult = homeController.Create() as ViewResult;
            //Assert
            Assert.IsNull(viewResult.ViewName);
        }
    }
}
