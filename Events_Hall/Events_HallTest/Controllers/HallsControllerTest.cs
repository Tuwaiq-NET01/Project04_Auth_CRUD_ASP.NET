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
    class HallsControllerTest
    {
        [Test]
        public void Index1_Halls_AreEqual()
        {
            //Arrange
            HallsController hallsController = new HallsController();
            //Act
            ViewResult viewResult = hallsController.Index1() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}
