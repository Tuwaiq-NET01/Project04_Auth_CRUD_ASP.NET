using System;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using NUnit.Framework;
using Final_project.Controllers;
using Final_project.Models;


namespace Final_projectTest.Contraller
{
    [TestFixture]
    public class ReservationsControllerTest
    {
        [Test]
        public void Test_Reservation_Null_View()
        {
            ReservationsController ControllerObj = new ReservationsController(null);


            ViewResult viewResult = ControllerObj.Create() as ViewResult;

            Assert.IsNull(viewResult.ViewName);
        }
    }
}
