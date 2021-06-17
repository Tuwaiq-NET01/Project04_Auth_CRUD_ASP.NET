using ExamApplication.Controllers;
using NUnit.Framework;
using System.Web.Mvc;

namespace ExamApplicationTesT
{
    [TestFixture]
    class AuthorizeStudentsControllerTest
    {
        [Test]
        public void Retuen_View_Index()
        {
            //Arrange
            AuthorizeStudentsController ControllerObj = new AuthorizeStudentsController();

            //Act
            ViewResult viewResultObj = ControllerObj.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", viewResultObj.ViewName);

        }
    }
}