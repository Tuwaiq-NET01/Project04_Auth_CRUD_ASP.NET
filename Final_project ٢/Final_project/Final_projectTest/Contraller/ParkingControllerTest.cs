using System;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using NUnit.Framework;
using Final_project.Controllers;

namespace Final_projectTest.Contraller
{
    [TestFixture]
    public class ParkingControllerTest
    {
        [Test]
        public void Test_Parking_Null_View()
        {
            ParkingController ControllerObj = new ParkingController(null);


            ViewResult viewResult = ControllerObj.Index() as ViewResult;

            Assert.IsNull(viewResult.ViewName);
        }
    }
}
