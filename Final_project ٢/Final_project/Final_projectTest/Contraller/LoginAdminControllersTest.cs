using System;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using NUnit.Framework;
using Final_project.Controllers;

namespace Final_projectTest.Contraller
{
    [TestFixture]
    public class LoginAdminControllersTest
    {
        [Test]
        public void Test_Login_Admin_NullView()
        {
            LoginAdmin ControllerObj = new LoginAdmin(null,null,null);


            ViewResult viewResult = ControllerObj.Login() as ViewResult;

            Assert.IsNull(viewResult.ViewName);
        }
    }
}
