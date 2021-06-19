using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using HjtProject.Controllers;

namespace HjtProject.Controllers
{
    public class HomeControllerTest
    {
        
        [Test]
        public void UintTestIndex()
        {
            HomeController home = new HomeController() ;
            var viewResultObj = home.Index();
            
            Assert.IsTrue( viewResultObj is ViewResult);
        }
    }
}