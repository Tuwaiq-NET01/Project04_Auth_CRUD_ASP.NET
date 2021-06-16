using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project04_Auth_CRUD_ASP.NET.Data;
using Project04_Auth_CRUD_ASP.NET.Models;

namespace Project04_Auth_CRUD_ASP.NET.Controllers
{
    [Authorize(Roles = "Admin")]
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
            Dictionary<string, int> TableHelper = new Dictionary<string, int>();
            foreach(var price in applicationDbContext)
            {
                if(TableHelper.ContainsKey(price.Barber.Name))
                {
                    TableHelper[price.Barber.Name]++;
                }
                else
                {
                    TableHelper.Add(price.Barber.Name, 1);
                }
            }
            ViewData["TableHelper"] = TableHelper;
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
        public IActionResult Create(Guid? id)
        {
            var barber = _context.Barbers.FirstOrDefault(p => p.Id == id);

            if(barber == null)
            {
                return NotFound();
            }

            ViewData["BarberName"] = barber.Name;
            ViewData["BarberId"] = barber.Id;
            var query = from time in _context.Times
                        let barberTimes = (from price in _context.Prices
                                           where price.BarberId == barber.Id
                                           select price.TimeId).ToList()
                        where barberTimes.Contains(time.Id) == false
                        select time;


           ViewData["TimeId"] = new SelectList(query, "Id", "Value");
            return View();
        }

        // POST: PriceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid? id, [Bind("Id,Value,TimeId")] PriceModel priceModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                priceModel.Id = Guid.NewGuid();
                priceModel.BarberId = (Guid) id;
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
            var _price = _context.Prices.Include(p => p.Time).Include(p => p.Barber).FirstOrDefault(p => p.Id == id);

            if (_price == null)
            {
                return NotFound();
            }

            var query = (from time in _context.Times
                        let barberTimes = (from price in _context.Prices
                                           where price.BarberId == _price.BarberId
                                           select price.TimeId).ToList()
                        where barberTimes.Contains(time.Id) == false
                        select time).ToList();

            query.Add(_price.Time);
            var priceModel = await _context.Prices.FindAsync(id);
            if (priceModel == null)
            {
                return NotFound();
            }
            ViewData["BarberName"] = _price.Barber.Name;
            ViewData["TimeId"] = new SelectList(query, "Id", "Value", priceModel.TimeId);
            return View(priceModel);
        }

        // POST: PriceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Value,TimeId,BarberId")] PriceModel priceModel)
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
            // mark for testing ****************************************************************************
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
