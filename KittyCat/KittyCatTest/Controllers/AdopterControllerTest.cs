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
            AdopterController adoptController = new AdopterController();
            //Act
            ViewResult viewResult = adoptController.Create() as ViewResult;
            //Assert
            Assert.IsNull(viewResult.ViewName);
        }
    }
}
