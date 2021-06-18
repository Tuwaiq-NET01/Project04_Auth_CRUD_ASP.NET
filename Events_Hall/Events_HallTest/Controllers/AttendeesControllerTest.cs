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
    class AttendeesControllerTest
    {
        [Test]
        public void Index1_Attendees_AreEqual()
        {
            //Arrange
            AttendeesController attendeesController = new AttendeesController();
            //Act
            ViewResult viewResult = attendeesController.Index1() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual(null, viewResult.ViewName);
        }
    }
}
