using Keraa.Data;
using Keraa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Controllers
{
    public class UserProfilesController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userProfile = _db.UserProfiles.ToList().Find(profile => profile.Id == user.Id);
            return View(userProfile);
        }


        [HttpPost]
        public async Task<IActionResult> Update([Bind("Id", "Name", "Bio", "Image")] UserProfileModel profile)
        {
           
            var userToUpdate = await _db.UserProfiles.FirstOrDefaultAsync(s => s.Id == profile.Id);
            if (await TryUpdateModelAsync<UserProfileModel>(
                userToUpdate,
                "",
                s => s.Name, s => s.Bio, s => s.Image))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator. You can Find me at GitHub: @1Riyad");
                }
            }
/*            _db.UserProfiles.Update(profile);
            _db.SaveChanges();*/
            return RedirectToAction("Index");
        }
    }
}
