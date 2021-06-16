using Bookworm_Project.Controllers;
using Bookworm_Project.Models;
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
    class ProfilesControllerTest
    {
        [Test]
        public void unitTestShowProfileWithoutUserManger_ThrowEx()
        {
            ProfilesController ControllerObj = new ProfilesController(null,null);


            Assert.ThrowsAsync<NullReferenceException>(async () => await ControllerObj.ShowAsync(""));
         
        }
    }       
}
