using ExamApplication.Controllers;

using NUnit.Framework;
using System.Web.Mvc;

namespace ExamApplicationTesT
{
    [TestFixture]
    public class AuthorizeAdminControllerTest
    {
        [Test]
        public void Retuen_View_Index()
        {
            //Arrange
            AuthorizeAdminController con = new AuthorizeAdminController();

            //Act
            ViewResult viewResult = con.Index() as ViewResult;
            //Assert
            Assert.AreEqual(null, viewResult.ViewName);


        }
    }
}
