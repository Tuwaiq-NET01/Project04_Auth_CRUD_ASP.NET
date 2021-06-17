using ExamApplication.Controllers;
using ExamApplication.Data;
using ExamApplication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExamApplicationTesT.Controllers
{
    [TestClass]
    class QuestionsControllerTest
    {
        [TestMethod]
        public void Type_Of_Answer_In_Questions()
        {
            //Arrange
            var ControllerObj = new QuestionsController(null);
         
            //Act
            bool TypeOfAnswer = ControllerObj.ViewBag.Answer.GetType() == typeof(List<Answers>);

            //Assert
            Assert.IsTrue(TypeOfAnswer);



        }
    }
}
