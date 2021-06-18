using HealthChoice_Final_crud_auth.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChoice_Proj4Test.Controllers
{
    [TestFixture]
    class EventsControllerTest
    {

        [Test]
        public void Details_ThrowsEx()
        {
            //Arrange
            EventsController eventsController = new EventsController();
            
            //Assert
            NUnit.Framework.Assert.Throws<NullReferenceException>(() => eventsController.Details(id: null));
        }
    }
}
