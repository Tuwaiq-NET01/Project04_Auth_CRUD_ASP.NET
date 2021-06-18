using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using KittyCat.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyCatTest.Controllers
{
    [TestFixture]
    class BreedControllerTest
    {
        [Test]
        public void IndexTest()
        {
            //Arrange
            BreedController BreedController = new BreedController();
            //Act
            ViewResult viewResult = BreedController.Details() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}
