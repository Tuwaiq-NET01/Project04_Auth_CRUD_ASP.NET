using ExamApplication.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ExamApplicationTesT.Controllers
{
    [TestClass]
    class AccountControllerTest
    {

        [TestMethod]
        public void Retuen_View_Login()
        {
            //Arrange
            var ControllerObj = new AccountController(null, null);

            //Act
            ViewResult viewResultObj = ControllerObj.Login() as ViewResult;

            //Assert
            Assert.AreEqual("Login", viewResultObj.ViewName);


        }
        [TestMethod]
        public void Retuen_View_Login_As_Student()
        {
            //Arrange
            var ControllerObj = new AccountController(null, null);
            //Act
            ViewResult viewResultObj = ControllerObj.loginAsStudents() as ViewResult;
            //Assert
            Assert.AreEqual("loginAsStudents", viewResultObj.ViewName);


        }
    }
}