using ExamApplication.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ExamApplicationTesT.Controllers
{
    [TestClass]
    class HomeControllerTest
    {
        [TestMethod]
        public void Retuen_View_Index()
        {
            //Arrange
            var ControllerObj = new HomeController();

            //Act
            ViewResult viewResultObj = ControllerObj.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", viewResultObj.ViewName);


        }
    }
}
