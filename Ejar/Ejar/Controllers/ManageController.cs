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
	public class ManageController : Controller
	{
		private readonly ApplicationDbContext _db;
		//private readonly ApplicationUser user;
		public ManageController(ApplicationDbContext context)
		{
			_db = context;
			
		}
		public IActionResult Index()
		{
			int id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			var user = _db.User.FirstOrDefault(u => u.Id == id);
			user.Account = _db.Account.Where(a => a.UserId == user.Id).FirstOrDefault<AccountModel>();
			user.Account.License = _db.License.Where(l => l.AccountId == user.Account.Id).FirstOrDefault<LicenseModel>();

			if (user == null)
			{
				return Content("Error");
			}

			
			ViewBag.User = user;
			return View();
		}

		[HttpPost]
		public IActionResult Index([Bind("Id, FirstName, LastName, PhoneNumber, Address")] AccountModel account)
		{
			int id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			var user = _db.User.FirstOrDefault(u => u.Id == id);
			user.Account = _db.Account.Where(a => a.UserId == user.Id).FirstOrDefault<AccountModel>();
			user.Account.License = _db.License.Where(l => l.AccountId == user.Account.Id).FirstOrDefault<LicenseModel>();

			account.UserId = id;
			_db.Account.Update(account);
			_db.SaveChanges();

			
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult UpdateLicense([Bind("Id, LicenseNumber, IssuingDate, ExpirationDate, LicensePhoto")] LicenseModel license)
		{
			int id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			var user = _db.User.FirstOrDefault(u => u.Id == id);
			user.Account = _db.Account.Where(a => a.UserId == user.Id).FirstOrDefault<AccountModel>();
			user.Account.License = _db.License.Where(l => l.AccountId == user.Account.Id).FirstOrDefault<LicenseModel>();
			license.AccountId = user.Account.Id;

		
			if (user.Account.License == null)
			{
				
				_db.License.Add(license);
				_db.SaveChanges();
				ViewBag.User = user;
				RedirectToAction("Added License");
			}

			
			_db.License.Update(license);
			_db.SaveChanges();
			ViewBag.User = user;
			Console.WriteLine(user.Account.License.IssuingDate);
			RedirectToAction("Updated License");
			return View("Index"); 
		}
	}
}
