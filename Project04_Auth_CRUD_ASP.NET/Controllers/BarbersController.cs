using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project04_Auth_CRUD_ASP.NET.Data;

namespace Project04_Auth_CRUD_ASP.NET.Models
{
    [Authorize]
    public class BarbersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BarberModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barbers.ToListAsync());
        }

        // GET: BarberModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barberModel = await _context.Barbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barberModel == null)
            {
                return NotFound();
            }

            return View(barberModel);
        }

        // GET: BarberModels/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BarberModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name")] BarberModel barberModel)
        {
            if (ModelState.IsValid)
            {
                barberModel.Id = Guid.NewGuid();
                _context.Add(barberModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barberModel);
        }

        // GET: BarberModels/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barberModel = await _context.Barbers.FindAsync(id);
            if (barberModel == null)
            {
                return NotFound();
            }
            return View(barberModel);
        }

        // POST: BarberModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] BarberModel barberModel)
        {
            if (id != barberModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barberModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberModelExists(barberModel.Id))
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
            return View(barberModel);
        }

        // GET: BarberModels/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barberModel = await _context.Barbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barberModel == null)
            {
                return NotFound();
            }

            return View(barberModel);
        }

        // POST: BarberModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var barberModel = await _context.Barbers.FindAsync(id);
            _context.Barbers.Remove(barberModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberModelExists(Guid id)
        {
            return _context.Barbers.Any(e => e.Id == id);
        }
    }
}
