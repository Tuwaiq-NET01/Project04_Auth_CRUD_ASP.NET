using ExamApplication.Controllers;
using ExamApplication.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace ExamApplicationTesT.Controllers
{
    [TestFixture]
    class StudentsControllerTest
    {
        [Test]
        public void Return_Null_If_do_not_have_Id()
        {
            //Arrange
            var ControllerObj = new StudentsController(null);
            //Act
            var DetailsNull = ControllerObj.Details(null);

            //Assert
            Assert.AreEqual(ControllerObj.NotFound(), DetailsNull);

        }


    }
}
