using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using mininet.Data;
using mininet.Controllers;
using System.Threading.Tasks;
using mininet.Models;
namespace mininetests.Controllers
{
    public class NotesControllerTest
    {
        private NotesController _note;
        private UserManager<AppUser> _userManager;
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MiniTest").Options;
            var _db = new ApplicationDbContext(options);
            _db.Database.EnsureDeleted();
            _note = new NotesController(_db, _userManager);
            seeding(_db);
        }
        [Test]
        public void Test_Delete_Valid_Input()
        {
            var result = _note.DeleteTest(1) as RedirectToActionResult;
            // System.Console.WriteLine(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public void Test_Delete_inValid_Input()
        {
            var result = _note.DeleteTest(null) as ViewResult;
            // System.Console.WriteLine(result);
            Assert.AreEqual("_NotFound", result.ViewName);
        }

        public void seeding(ApplicationDbContext _db)
        {
            NoteModel[] notes = new[]
            {
                new NoteModel { Id = 1, Title = "test Note", Content = "Bla Bla"}
            };
            _db.notes.AddRange(
                notes
            );
            _db.SaveChanges();
        }
    }
}