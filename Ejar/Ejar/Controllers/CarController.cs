using Ejar.Data;
using Ejar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ejar.Controllers
{
	[Authorize]
	public class CarController : Controller
	{
		//database context
		private readonly ApplicationDbContext _db;
		public CarController(ApplicationDbContext context)
		{
			_db = context;
		}

		public AccountModel getUserAccount(int id)
		{
			int i = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			var user = _db.User.FirstOrDefault(u => u.Id == i);
			user.Account = _db.Account.Where(a => a.UserId == user.Id).FirstOrDefault<AccountModel>();

			return user.Account;
		}
		public CarModel getCar(int id)
		{
			var car = _db.Car.ToList().Find(c => c.Id == id);
			var Images = _db.Image.Where(i => i.CarId == car.Id).ToList();
			if (Images != null)
			{
				foreach (var img in Images)
				{
					car.Images.Add(img);
				}
			}
			if (id == null || car == null)
			{
				return null;
			}

			return car;
		}
		public IActionResult Index(int id)
		{

			ViewBag.Car = getCar(id);
			
			
			ViewBag.Account = getUserAccount(id);
			
			return View();
		}

		public IActionResult Create()
		{
			ViewBag.Car = new CarModel();
			return View();
		}

		//POST - /Car/Create
		[HttpPost]
		public ActionResult Create([Bind("Id, CarName, Manufacturer, Type, Year, PlateNumber, DayPrice, HourPrice, Available, Images")] CarModel car)
		{
			try
			{
				if (ModelState.IsValid)
				{
					car.UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
					car.DayPrice = Convert.ToDecimal(car.DayPrice);
					car.HourPrice = Convert.ToDecimal(car.HourPrice);

					_db.Car.Add(car);
					_db.SaveChanges();
					return RedirectToAction("Index", "Manage");
				}
			}
			catch (DataException)
			{

			}
			return View(car);
		}

		// GET - /Car/edit/id
		public IActionResult Edit(int? id)
		{
			var car = _db.Car.ToList().Find(m => m.Id == id);
			if (id == null || car == null)
			{
				return View("_NotFound");
			}
			ViewBag.Car = car;
			return View();
		}

		// POST - /Car/edit
		[HttpPost]
		public IActionResult Edit([Bind("Id, CarName, Manufacturer, Type, Year, PlateNumber, DayPrice, HourPrice, Available")] CarModel car)
		{

			if (car == null)
			{
				return View("_NotFound");
			}
			car.UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			_db.Car.Update(car);
			_db.SaveChanges();

			ViewBag.Car = car;
			return View();
		}

		// POST - /Car/delete/id
		[HttpPost]
		public IActionResult Delete(int? id)
		{
			var car = _db.Car.ToList().FirstOrDefault(m => m.Id == id);
			if (id == null || car == null)
			{
				return View("_NotFound");
			}
			_db.Car.Remove(car);
			_db.SaveChanges();

			return RedirectToAction("Index", "Manage");
		}

		public IActionResult Rent()
		{
			
			return View();
		}


	}
}
