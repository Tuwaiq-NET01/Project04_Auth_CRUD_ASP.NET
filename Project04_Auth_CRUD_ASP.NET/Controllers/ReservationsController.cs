using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project04_Auth_CRUD_ASP.NET.Data;
using Project04_Auth_CRUD_ASP.NET.Models;

namespace Project04_Auth_CRUD_ASP.NET.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservationModels
        public async Task<IActionResult> Index()
        {
            // could have used Include instead
            var query = from reservation in _context.Reservations join price in _context.Prices
                        on reservation.PriceId equals price.Id join barber in _context.Barbers on
                        price.BarberId equals barber.Id join time in _context.Times on price.TimeId equals time.Id
                        where reservation.UserId == new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value)
                        select new ReservationJoin(){ Id = reservation.Id, Day = reservation.Day, Time = time.Value, Barber = barber.Name};

            return View(await query.ToListAsync());
        }

        // GET: ReservationModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .Include(r => r.Price)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            return View(reservationModel);
        }

        // GET: ReservationModels/Create
        public IActionResult Create(Guid? id)
        {
            var barber = _context.Barbers.FirstOrDefault(p => p.Id == id);
            if(barber == null)
            {
                return NotFound();
            }

            var query = from price in _context.Prices 
                        where price.BarberId == barber.Id
                        join time in _context.Times on price.TimeId equals time.Id
                        select new { Id = price.Id, Text = time.Value+ " $ "+price.Value };

            ViewData["BarberName"] = barber.Name;
            ViewData["PriceId"] = new SelectList(query, "Id", "Text");
            return View();
        }

        // POST: ReservationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Day,PriceId")] ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                var same_res = _context.Reservations.FirstOrDefault(r => r.Day == reservationModel.Day && r.PriceId == reservationModel.PriceId);

                if(same_res != null)
                {
                    var barber = _context.Prices.Include(p => p.Barber).FirstOrDefault(p => p.Id == reservationModel.PriceId).Barber;
                    if (barber == null)
                    {
                        return NotFound();
                    }

                    var query = from price in _context.Prices
                                where price.BarberId == barber.Id
                                join time in _context.Times on price.TimeId equals time.Id
                                select new { Id = price.Id, Text = time.Value + " $ " + price.Value };

                    ViewData["message"] = barber.Name + " is already booked";
                    ViewData["BarberName"] = barber.Name;
                    ViewData["PriceId"] = new SelectList(query, "Id", "Text");
                    return View(reservationModel);
                }

                reservationModel.Id = Guid.NewGuid();
                reservationModel.UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                _context.Add(reservationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriceId"] = new SelectList(_context.Prices, "Id", "Id", reservationModel.PriceId);
            return View(reservationModel);
        }

        // GET: ReservationModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations.FindAsync(id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            var barberID = _context.Reservations.Include(r => r.Price).FirstOrDefault(p => p.Id == id).Price.BarberId;
            var barber = _context.Barbers.FirstOrDefault(b => b.Id == barberID);

            if (barber == null)
            {
                return NotFound();
            }

            var query = from price in _context.Prices
                        where price.BarberId == barber.Id
                        join time in _context.Times on price.TimeId equals time.Id
                        select new { Id = price.Id, Text = time.Value + " $ " + price.Value };

            ViewData["BarberName"] = barber.Name;
            ViewData["PriceId"] = new SelectList(query, "Id", "Text");
            return View(reservationModel);
        }

        // POST: ReservationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Day,PriceId")] ReservationModel reservationModel)
        {
            if (id != reservationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var same_res = _context.Reservations.FirstOrDefault(r => r.Day == reservationModel.Day && r.PriceId == reservationModel.PriceId);

                if (same_res != null)
                {
                    var barber = _context.Prices.Include(p => p.Barber).FirstOrDefault(p => p.Id == reservationModel.PriceId).Barber;
                    if (barber == null)
                    {
                        return NotFound();
                    }

                    var query = from price in _context.Prices
                                where price.BarberId == barber.Id
                                join time in _context.Times on price.TimeId equals time.Id
                                select new { Id = price.Id, Text = time.Value + " $ " + price.Value };

                    ViewData["message"] = barber.Name + " is already booked";
                    ViewData["BarberName"] = barber.Name;
                    ViewData["PriceId"] = new SelectList(query, "Id", "Text");
                    return View(reservationModel);
                }
                try
                {
                    reservationModel.UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    _context.Update(reservationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationModelExists(reservationModel.Id))
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
            ViewData["PriceId"] = new SelectList(_context.Prices, "Id", "Id", reservationModel.PriceId);
            return View(reservationModel);
        }

        // GET: ReservationModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .Include(r => r.Price)
                .Include(r => r.Price.Time)
                .Include(r => r.Price.Barber)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            return View(reservationModel);
        }

        // POST: ReservationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var reservationModel = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationModelExists(Guid id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
