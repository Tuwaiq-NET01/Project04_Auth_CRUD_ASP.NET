using ExamApplication.Controllers;
using ExamApplication.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ExamApplicationTesT.Controllers
{
    [TestClass]
    class AnswersControllerTest
    {
    
        [TestMethod]
        public void Redirct_To_Specifc_Action()
        {
            //Arrange
            var ControllerObj = new AnswersController(null);
            //Act
            var viewResultObj = ControllerObj.RedirectToAction("Edit", "Questions");
            //Assert
            Assert.AreEqual(ControllerObj.Create(1), viewResultObj);


        }
    }
}
