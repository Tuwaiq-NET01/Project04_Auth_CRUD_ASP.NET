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
    public class StudentsController : Controller
    {
        private readonly MyDbContext _db;

        public StudentsController(MyDbContext context)
        {
            _db = context;
        }

        public StudentsController()
        {
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _db.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _db.Student
                .FirstOrDefaultAsync(m => m.id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,userName,password,RememberMe")] Students students)
        {
            if (ModelState.IsValid)
            {
                _db.Add(students);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _db.Student.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,userName,password,RememberMe")] Students students)
        {
            if (id != students.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(students);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _db.Student
                .FirstOrDefaultAsync(m => m.id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var students = await _db.Student.FindAsync(id);
            _db.Student.Remove(students);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentsExists(long id)
        {
            return _db.Student.Any(e => e.id == id);
        }
    }
}
