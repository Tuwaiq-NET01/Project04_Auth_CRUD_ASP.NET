using ConferenceRoomManager.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRoomManager.Data
{
    public class ApplicationUser : IdentityUser
    {
        List<BookingModel> Bookings { get; set; }
    }
}
