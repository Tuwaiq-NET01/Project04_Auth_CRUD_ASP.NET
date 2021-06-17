using Ejar.Data;
using Ejar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
			List<CarModel> Cars = null;
			if (User.Identity.IsAuthenticated)
			{
				int id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
				Cars = _db.Car.Where(c => c.UserId != id).ToList();
			}
			else
			{
				Cars = _db.Car.ToList();
			}
			

			foreach (var car in Cars)
			{
				var Images = _db.Image.Where(i => i.CarId == car.Id).ToList();
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
