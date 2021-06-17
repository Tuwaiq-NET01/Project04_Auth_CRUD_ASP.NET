using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamApplication.Models;
using ExamApplication.Data;

namespace ExamApplication.Controllers
{
    public class AdminsController : Controller
    {
        private readonly MyDbContext _db;
        public AdminsController(MyDbContext context)
        {
            _db = context;
        }
      

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return View(await _db.Admin.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admins = await _db.Admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admins == null)
            {
                return NotFound();
            }

            return View(admins);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: Admins/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userName,password,RememberMe")] Admins admins)
        {
            if (ModelState.IsValid)
            {
                _db.Add(admins);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(admins);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admins = await _db.Admin.FindAsync(id);
            if (admins == null)
            {
                return NotFound();
            }
            return View(admins);
        }

        // POST: Admins/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,userName,password,RememberMe")] Admins admins)
        {
            if (id != admins.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(admins);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminsExists(admins.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admins);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admins = await _db.Admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admins == null)
            {
                return NotFound();
            }

            return View(admins);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var admins = await _db.Admin.FindAsync(id);
            _db.Admin.Remove(admins);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AdminsExists(long id)
        {
            return _db.Admin.Any(e => e.id == id);
        }
    }
}
