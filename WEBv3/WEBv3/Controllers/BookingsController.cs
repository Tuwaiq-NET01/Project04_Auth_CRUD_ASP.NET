using WEBv3.Data;
using WEBv3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Text;

namespace WEBv3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public string decodepaloads(string token)
        {
            var jsonToken = new JwtSecurityTokenHandler().ReadToken(token.Replace("Bearer ", ""));
            var tokenData = jsonToken as JwtSecurityToken;
            var userId = tokenData.Claims.First(claim => claim.Type == "uid").Value;
            return userId;
        }


        public BookingsController(ApplicationDbContext db)
        {
            _db = db;
        }




        [HttpPost]

        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            Booking b = new Booking();
            b.adult = booking.adult;
            b.child = booking.child;
            int adultNum = Convert.ToInt32(booking.adult);
            int childNum = Convert.ToInt32(booking.child);
            var specificTour = await _db.Tours.FindAsync(booking.TourId);

            int adultPrice = Convert.ToInt32(specificTour.AdultPrice);
            int childPrice = Convert.ToInt32(specificTour.ChildPrice);

            b.total = (adultNum * adultPrice + childNum * childPrice);
            //   b.total = booking.total;
            b.firstName = booking.firstName;
            b.LastName = booking.LastName;
            b.email = booking.email;
            b.TourId = booking.TourId;

            await this._db.Bookings.AddAsync(b);
            await this._db.SaveChangesAsync();
            return Ok(b);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Booking>> Delete([FromRoute] int id)
        {
            Booking b = await this._db.Bookings.FirstOrDefaultAsync(t => t.id == id);
            if (b == null)
                return NotFound();
            this._db.Bookings.Remove(b);
            await this._db.SaveChangesAsync();
            return Ok(b);
        }



        // PUT: api/Tours/5
        [Route("aprove/{id}")]
        [HttpPut]
        public async Task<IActionResult> Aprove(int id)
        {
            Booking foundBooking = await this._db.Bookings.FirstOrDefaultAsync(t => t.id == id);
            if (foundBooking == null)
                return NotFound();
            foundBooking.status = true;
            this._db.Bookings.Update(foundBooking);
            await this._db.SaveChangesAsync();           
            var a = Task.Factory.StartNew(() => SendEmail(foundBooking.email));
            return Ok(foundBooking);

        }

        [NonAction]
        public void SendEmail(string reciever)
        {
            MailMessage message = new MailMessage("rhmbooking123@gmail.com", reciever);
            message.Subject = "Booking Confirmation - KSA Tour";
            message.Body = GetApproveEmailBody();
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587; //25           
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("rhmbooking123@gmail.com", "");
            client.Credentials = basicCredential1;
            try
            {
                client.EnableSsl = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        private string GetApproveEmailBody()
        {
            string htmldata = "Dear Customer,<br /><br />" +
                "You are pleased to inform you that your booking is received and confirmed<br /><br />" +
                "Thankyou<br />" +
                "KSA Tours";
            return htmldata;
        }

        /* [HttpPut("{id}")]
       public async Task<IActionResult> Bookings(int id, Booking booking)
       {
           Booking foundBooking = await this._db.Bookings.FirstOrDefaultAsync(t => t.id == id);
           if (foundBooking == null)
               return NotFound();
           foundBooking.adult = booking.adult;
           foundBooking.child = booking.child;
           foundBooking.total = booking.total;
           foundBooking.firstName = booking.firstName;
           this._db.Bookings.Update(foundBooking);
           await this._db.SaveChangesAsync();
           return Ok(foundBooking);

       }*/

        /*
          int id 
         int adult 
         int child 
         int total 
         string firstName 
         string LastName
         int TourId 
         Tour Tour 

         */



    }
}
