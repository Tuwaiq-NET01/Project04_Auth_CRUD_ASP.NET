using ExamApplication.Controllers;
using ExamApplication.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ExamApplicationTesT.Controllers
{
    [TestClass]
    class AdminsControllerTesT
    {
       
        [TestMethod]
        public void Return_Null_If_do_not_have_Id()
        {
            //Arrange
            var ControllerObj = new AdminsController(null);
            //Act
           var DetailsNull = ControllerObj.Details(null);

            //Assert
            Assert.AreEqual(ControllerObj.NotFound(), DetailsNull);

        }


    }
}
