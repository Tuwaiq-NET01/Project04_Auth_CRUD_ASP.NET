using Ejar.Data;
using Ejar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _db;
		public HomeController(ApplicationDbContext context)
		{
			_db = context;

		}

	
		public IActionResult Index()
		{
			var Cars = _db.Car.ToList();
			var Images = _db.Image.ToList();
			foreach (var car in Cars)
			{
				foreach (var img in Images)
				{
					car.Images.Add(img);
				}
			}
			ViewBag.Cars = Cars;
			return View();
		}
		[Authorize]
		public IActionResult Profile()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
