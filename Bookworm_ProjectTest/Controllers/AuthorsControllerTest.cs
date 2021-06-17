using Bookworm_Project.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm_ProjectTest.Controllers
{
    [TestFixture]
    class AuthorsControllerTest
    {
        [Test]
        public void unitTestCreateAuthorWithoutAuthorize_NullView()
        {
            AuthorsController ControllerObj = new AuthorsController(null,null);


            ViewResult viewResult = ControllerObj.Create() as ViewResult;
            
            Assert.IsNull(viewResult.ViewName);
        }
    }   
}
