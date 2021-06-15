using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project04_Auth_CRUD_ASP.NET.Data;
using Project04_Auth_CRUD_ASP.NET.Models;

namespace Project04_Auth_CRUD_ASP.NET.Controllers
{
    public class PricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PriceModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prices.Include(p => p.Barber).Include(p => p.Time);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PriceModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceModel = await _context.Prices
                .Include(p => p.Barber)
                .Include(p => p.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceModel == null)
            {
                return NotFound();
            }

            return View(priceModel);
        }

        // GET: PriceModels/Create
        public IActionResult Create()
        {
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Name");
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Value");
            return View();
        }

        // POST: PriceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,BarberId,TimeId")] PriceModel priceModel)
        {
            if (ModelState.IsValid)
            {
                priceModel.Id = Guid.NewGuid();
                _context.Add(priceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Name", priceModel.BarberId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Value", priceModel.TimeId);
            return View(priceModel);
        }

        // GET: PriceModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceModel = await _context.Prices.FindAsync(id);
            if (priceModel == null)
            {
                return NotFound();
            }
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Name", priceModel.BarberId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Value", priceModel.TimeId);
            return View(priceModel);
        }

        // POST: PriceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Value,BarberId,TimeId")] PriceModel priceModel)
        {
            if (id != priceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceModelExists(priceModel.Id))
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
            ViewData["BarberId"] = new SelectList(_context.Barbers, "Id", "Name", priceModel.BarberId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Value", priceModel.TimeId);
            return View(priceModel);
        }

        // GET: PriceModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceModel = await _context.Prices
                .Include(p => p.Barber)
                .Include(p => p.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceModel == null)
            {
                return NotFound();
            }

            return View(priceModel);
        }

        // POST: PriceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var priceModel = await _context.Prices.FindAsync(id);
            _context.Prices.Remove(priceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceModelExists(Guid id)
        {
            return _context.Prices.Any(e => e.Id == id);
        }
    }
}
