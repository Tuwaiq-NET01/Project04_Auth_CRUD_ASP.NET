using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
namespace HotelReservationManagement.Models
{

    public class AdvanceUser:IdentityUser
    {
      

        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int MobileNumber { get; set; }

        [DefaultValue(true)]
        public bool Admin { get; set; }
    }
}