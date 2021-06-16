using Microsoft.AspNetCore.Identity;

namespace HotelReservationManagement.Models
{
    public class AdvanceUser:IdentityUser
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int MobileNumber { get; set; }

    }
}