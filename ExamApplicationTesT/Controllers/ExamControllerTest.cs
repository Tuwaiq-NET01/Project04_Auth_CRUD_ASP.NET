using ExamApplication.Controllers;
using ExamApplication.Data;
using ExamApplication.Models;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System.Web.Mvc;

namespace ExamApplicationTesT
{
    [TestFixture]
    class ExamControllerTest
    {
       
        [Test]
         
        public void Return_Type_Of_ViewBag_QuestionCounter()
        {
            ExamController Controller = new ExamController(null);


           bool TypeOfCount = Controller.ViewBag.QuestionCounter.GetType() == typeof(long);

            Assert.IsTrue(TypeOfCount);
        }

    }
}