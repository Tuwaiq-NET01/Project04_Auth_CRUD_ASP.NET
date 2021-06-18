using HealthChoice_Final_crud_auth.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChoice_Proj4Test.Controllers
{
    [TestFixture]
    class ServicesControllerTest
    {
        [Test]
        public void Index2_AreEqual()
        {
            //Arrange
            ServicesController servicesController = new ServicesController();
            //Act
            ViewResult viewResult = servicesController.Index1() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual(null, viewResult.ViewName);
        }

    }

}
