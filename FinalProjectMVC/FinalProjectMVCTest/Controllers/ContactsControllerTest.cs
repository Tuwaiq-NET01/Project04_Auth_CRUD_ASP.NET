using FinalProjectMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectMVCTest.Controllers
{
    [TestFixture]
    class ContactsControllerTest
    {
        [Test]
        public void Index_Return_Corrected_Index_View()
        {
            //Arrange
            ContactsController contacts = new ContactsController(null);
            //Act
            ViewResult viewResultObj = contacts.Index() as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResultObj.ViewName);

        }
            /*public void create3_Throw_ArgumentException_When_ModelState_IsInvalid()
        {
            // Arrange
            var controller = new ContactsController();
            //Assert
            *//*  Assert.Throws<ArgumentException>(() => { controller.Create3(); });*//*
            Assert.That(() => controller.Create3(["Name", "Email", "PhoneNo", "Massage"],controller), Throws.TypeOf<ArgumentException>());
        }*/
        }
    
}

