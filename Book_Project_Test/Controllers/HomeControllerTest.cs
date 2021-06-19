using Book_Project.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Project_Test.Controllers
{
    
    class HomeControllerTest
    {
        [Test]
        public void Action_Index_ViewResult()
        {
            HomeController home = new HomeController();

            ViewResult view = home.Index() as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
        }
    }
}
