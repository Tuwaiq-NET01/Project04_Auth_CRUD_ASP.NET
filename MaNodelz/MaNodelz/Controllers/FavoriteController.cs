using MaNodelz.Data;
using MaNodelz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaNodelz.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly ApplicationDbContext _db;
       

        public FavoriteController(ApplicationDbContext dp )
        {
            _db = dp;
           
        }
        // user go to the dishes page and click the fav button => added to the user fav dishes

        [Authorize]
        [HttpPost]
        public IActionResult AddToFavCart(int? id)
        {
            try {
                int userID = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value); 
                var food = _db.Food.FirstOrDefault(p => p.Id == id);
                if (id == null || food == null)
                {
                    return View("_NotFound");
                }

                var favCart = new FavoriteModel() { UserId = userID, Food = food, Fav = true };
                _db.Favorites.Add(favCart);
                _db.SaveChanges();
                return RedirectToAction("AddToFavCart");
            }
            catch
            {
                Console.WriteLine( "Error accord" ); 
            }

            return RedirectToAction("Index", "Food");
        }

    }
}
