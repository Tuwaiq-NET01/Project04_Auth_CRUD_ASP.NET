using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mininet.Models;
using Microsoft.AspNetCore.Authorization;
using mininet.Data;
using Microsoft.AspNetCore.Identity;
using CodeHollow.FeedReader;

namespace mininet.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> userManager;
        public NotesController(
            ApplicationDbContext context,
            UserManager<AppUser> userMngr
            )
        {
            _db = context;
            userManager = userMngr;
        }

        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);
            var notes = _db.notes.Where( n => n.UserId == userId).ToList();
            ViewData["notes"] = notes;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind] NoteModel note)
        {
            if(ModelState.IsValid)
            {
                var userId = userManager.GetUserId(User);
                note.UserId = userId;
                await _db.notes.AddAsync(note);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["errors"] = "Invalid Inputs, please make sure your inputs are correct.";
            return View(note);
        }

        public IActionResult Edit([FromRoute] long? id )
        {
            var userId = userManager.GetUserId(User);
            var note = _db.notes.FirstOrDefault( n => n.Id == id && n.UserId == userId);
            if( note == null || id == null )
                return View("_NotFound");
            ViewData["note"] = note;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind] NoteModel note)
        {
            if(ModelState.IsValid)
            {
                note.UserId = userManager.GetUserId(User);
                _db.notes.Update(note);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            // ViewData["errors"] = "Invalid Inputs, please make sure your inputs are correct.";
            return View(note); 
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] long? id)
        {
            var userId = userManager.GetUserId(User);
            var note = _db.notes.FirstOrDefault( n => n.Id == id && n.UserId == userId);
            if( id == null || note == null)
                return View("_NotFound");
            _db.notes.Remove(note);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [NonAction]
        public IActionResult DeleteTest( long? id)
        {
            var note = _db.notes.FirstOrDefault( n => n.Id == id);
            if( id == null || note == null)
                return View("_NotFound");
            _db.notes.Remove(note);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}