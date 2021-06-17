using Ejar.Data;
using Ejar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ejar.Controllers
{
	[Authorize]
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

		public int getDays(string DateReservedFrom, string DateReservedUntil)
		{
			TimeSpan span = (DateTime.Parse(DateReservedUntil) - DateTime.Parse(DateReservedFrom));

		
			return span.Days;
		}

		private int getHours(string dateAndTimeFrom, string dateAndTimeUntil)
		{
			DateTime from = DateTime.Parse(dateAndTimeFrom);
			DateTime to = DateTime.Parse(dateAndTimeUntil);

			TimeSpan span = to - from;

			return span.Hours;
		}

		private string calculateTax(int days, int hours, decimal dayPrice, decimal hourPrice)
		{
			//daily price 
			decimal DaysTotalCost = Convert.ToDecimal(days) * dayPrice;
			//hours price
			decimal HoursTotalCost = Convert.ToDecimal(hours) * hourPrice;

			decimal TotalCostWithoutTax = DaysTotalCost + HoursTotalCost;
			decimal TotalTax = TotalCostWithoutTax * 15 / 100;
			return "15% - " + TotalTax;
		}

		private decimal getTotal(int days, int hours, decimal dayPrice, decimal hourPrice, string tax)
		{
			//daily price 
			decimal DaysTotalCost = Convert.ToDecimal(days) * dayPrice;
			//hours price
			decimal HoursTotalCost = Convert.ToDecimal(hours) * hourPrice;

			decimal TotalTax = (DaysTotalCost + HoursTotalCost) * 15 / 100;
			decimal TotalPriceIncludingTax = DaysTotalCost + HoursTotalCost + TotalTax;

			return TotalPriceIncludingTax;
		}

		public IActionResult Price([Bind("Id, DateReservedFrom, TimeReservedFrom, DateReservedUntil, TimeReservedUntil, TripPrice")] TripModel trip, int? id)
		{
			var car = _db.Car.ToList().FirstOrDefault(m => m.Id == id);
			car.Images = _db.Image.ToList();
			if (id == null || car == null)
			{
				return View("_NotFound");
			}
			
			//get the needed info to calculate price
			int days = getDays(trip.DateReservedFrom + " " + trip.TimeReservedFrom, trip.DateReservedUntil + " " + trip.TimeReservedUntil);
			int hours = getHours(trip.DateReservedFrom + " " + trip.TimeReservedFrom + ":00", trip.DateReservedUntil + " " + trip.TimeReservedUntil + ":00");
			string tax = calculateTax(days, hours, car.DayPrice, car.HourPrice);

			//send data to view
			ViewBag.Car = car;
			ViewBag.trip = trip;
			ViewBag.Days = days;
			ViewBag.Hours = hours;
			ViewBag.Tax = tax;
			ViewBag.Total = getTotal(days, hours, car.DayPrice, car.HourPrice, tax);
			return View();
		}


		[HttpPost]
		public ActionResult Create([Bind("DateReservedFrom, TimeReservedFrom, DateReservedUntil, TimeReservedUntil, TripPrice")] TripModel trip, int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
					trip.UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
					//make car unavailable
					var car = _db.Car.ToList().FirstOrDefault(m => m.Id == id);
					car.Available = "False";
					_db.Car.Update(car);
					_db.SaveChanges();

					//add trip
					trip.Car = car;
					_db.Trip.Add(trip);
					_db.SaveChanges();
					return RedirectToAction("Index", "Manage");
				}
			}
			catch (DataException)
			{

			}
			return RedirectToAction("Index", "Manage");
		}
	}
}
