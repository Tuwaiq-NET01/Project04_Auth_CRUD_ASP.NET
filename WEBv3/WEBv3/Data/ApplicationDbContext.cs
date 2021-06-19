using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEBv3.Models;

namespace WEBv3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Tour> Tours { get; set; }
        public DbSet<Included> Includeds { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
