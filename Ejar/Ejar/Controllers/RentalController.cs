using Ejar.Data;
using Ejar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ejar.Controllers
{
	public class RentalController : Controller
	{
		private readonly ApplicationDbContext _db;
		//private readonly ApplicationUser user;
		public RentalController(ApplicationDbContext context)
		{
			_db = context;

		}
		public IActionResult Index(CarModel car)
		{
			return View();
		}


		public IActionResult Rent(int? id)
		{
			var car = _db.Car.ToList().FirstOrDefault(m => m.Id == id);
			if (id == null || car == null)
			{
				return View("_NotFound");
			}

			ViewBag.Car = car;
			return View();
		}

		public IActionResult Price([Bind("Id, DateReservedFrom, TimeReservedFrom, DateReservedUntil, TimeReservedUntil, TripPrice")] TripModel trip, int? id)
		{
			var car = _db.Car.ToList().FirstOrDefault(m => m.Id == id);
			car.Images = _db.Image.ToList();
			if (id == null || car == null)
			{
				return View("_NotFound");
			}
			ViewBag.Car = car;
			ViewBag.trip = trip;
			return View();
		}

		public ActionResult Create([Bind("Id, ReservedFrom, ReservedUntil, TripPrice")] TripModel trip)
		{
			try
			{
				if (ModelState.IsValid)
				{
					trip.UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
					

					_db.Trip.Add(trip);
					_db.SaveChanges();
					return RedirectToAction("Index", "Manage");
				}
			}
			catch (DataException)
			{

			}
			return View();
		}
	}
}
