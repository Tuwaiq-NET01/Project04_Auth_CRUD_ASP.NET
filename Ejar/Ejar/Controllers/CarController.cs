using Ejar.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public IActionResult Index(int? id)
		{
			var car = _db.Car.ToList().Find(c => c.Id == id);
			if (id == null || car == null)
			{
				return View("_NotFound");
			}
			ViewBag.Car = car;
			return View(car);
		}
	}
}
