using Events_Hall.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_HallTest.Controllers
{
    [TestFixture]
    class PresentorsControllerTest
    {
        [Test]
        public void Create_Presentors_AreEqual()
        {
            //Arrange
            PresentorsController presentorsController = new PresentorsController();
            //Act
            ViewResult viewResult = presentorsController.Create() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Create",viewResult.ViewName);
        }
    }
}