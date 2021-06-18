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
    class EventsControllerTest
    {
        [Test]
        public void Details_Events_AreEqual()
        {
            //Arrange
            EventsController eventsController = new EventsController();
            //Act
            ViewResult viewResult = eventsController.Details1(id: null) as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("_NotFound", viewResult.ViewName);
        }
    }
}
