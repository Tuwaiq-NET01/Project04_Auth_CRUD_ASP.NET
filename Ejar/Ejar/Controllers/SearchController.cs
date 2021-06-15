using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Controllers
{
	public class SearchController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
