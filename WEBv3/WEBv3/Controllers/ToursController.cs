using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WEBv3.Data;
using WEBv3.Models;
using WEBv3.Helpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace WEBv3.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ToursController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = context;
        }


        // to decode the payload coming with the request
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public string decodepaloads(string token)
        {
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(token.Replace("Bearer ", ""));
            var tokenData = jsonToken as JwtSecurityToken;
            var userId = tokenData.Claims.First(claim => claim.Type == "uid").Value;
            return userId;
        }
    

      
        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {


            var token = Request.Headers[HeaderNames.Authorization].FirstOrDefault();
            var userId = decodepaloads(token);
            return await _db.Tours.Where(t => t.UserId == userId).ToListAsync();



          //  return await _db.Tours.ToListAsync();



        }

       /* [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _db.Tours.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }
*/

        // GET: api/Tours/5

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tour>> GetOne([FromRoute] int id)
        {
            var token = Request.Headers[HeaderNames.Authorization].FirstOrDefault();
            var userId = decodepaloads(token);

            var tour1 = await _db.Tours.FindAsync(id);
            if (tour1 == null )
            {
                return NotFound("Sorry not found");

            }

            if (userId != tour1.UserId)
            {
                return NotFound("you are not authorized");
            }

            var tour = await _db.Tours.Include(i => i.Included).FirstOrDefaultAsync(t => t.TourId == id);
            //   IQueryable<Tour> tours = _db.Tours.Where(t => t.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }





        // PUT: api/Tours/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, Tour tour)
        {

            var token = Request.Headers[HeaderNames.Authorization].FirstOrDefault();
            var userId = decodepaloads(token);
            Tour foundTour = await this._db.Tours.FirstOrDefaultAsync(tour => tour.TourId == id);

            if (userId != foundTour.UserId)
            {
                return NotFound("you are not authorized");
            }

            if (foundTour == null)
                return NotFound();
            foundTour.Place = tour.Place;
            foundTour.Description = tour.Description;
            foundTour.AdultPrice = tour.AdultPrice;
            foundTour.ChildPrice = tour.ChildPrice;
            foundTour.PickupLocation = tour.PickupLocation;
            foundTour.ReturnsAt = tour.ReturnsAt;
            foundTour.DepartsAt = tour.DepartsAt;
            foundTour.Image = tour.Image;
           // Included inc = new Included();
            Included inc = await this._db.Includeds.FirstOrDefaultAsync(i => i.TourId == foundTour.TourId);

          //  inc.TourId = foundTour.TourId;
            // find the inclouded by id 
            inc.TourGuide = tour.Included.TourGuide;
            inc.Transport = tour.Included.Transport;
            inc.EntiranceFees = tour.Included.EntiranceFees;
            inc.PickUpAndDrop = tour.Included.PickUpAndDrop;
            inc.Food = tour.Included.Food;
            this._db.Includeds.Update(inc);


            /*
IncludedId 
TourGuide 
Transport 
EntiranceFees 
PickUpAndDrop
Food */

            //   foundTour.Included = inc;
            this._db.Tours.Update(foundTour);
            await this._db.SaveChangesAsync();
            return Ok(foundTour);




        }

        






        // POST: api/Tours
        [HttpPost]
        public async Task<ActionResult<Tour>> Create([FromBody] Tour tour)
        {
            var token = Request.Headers[HeaderNames.Authorization].FirstOrDefault();
            var userId = decodepaloads(token);
            tour.UserId = userId;
            await this._db.Tours.AddAsync(tour);
            await this._db.SaveChangesAsync();
            return Ok(tour);
        }






        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {

            var token = Request.Headers[HeaderNames.Authorization].FirstOrDefault();
            var userId = decodepaloads(token);

           var tour = await _db.Tours.FindAsync(id);

            if (userId != tour.UserId)
            {
                return NotFound("you are not authorized");
            }




            if (tour == null)
            {
                return NotFound();
            }

            _db.Tours.Remove(tour);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool TourExists(int id)
        {
            return _db.Tours.Any(e => e.TourId == id);
        }





        [NonAction]
        public async Task<string> SaveImage(IFormFile ImageFile)

        {
            string ImageName = new string(Path.GetFileNameWithoutExtension(ImageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            ImageName = ImageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(ImageFile.FileName);
            var ImagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "TourImages", ImageName);
            using (var fileStream = new FileStream(ImagePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }
            return ImageName;
        }

        [HttpPut("img")]

        public async Task<ActionResult<Tour>> updateImage([FromForm] Update tour)
        {
           

            Tour foundTour = await this._db.Tours.FirstOrDefaultAsync(t => t.TourId == tour.id);

            if (tour.ImageFile != null)
            {
                foundTour.Image = await SaveImage(tour.ImageFile);
            }
            else
            {
                foundTour.Image = "";
            }

            //  await this._db.Tours.AddAsync(tour);
            this._db.Tours.Update(foundTour);

            await this._db.SaveChangesAsync();
            return Ok(tour);
        }









    }
}
