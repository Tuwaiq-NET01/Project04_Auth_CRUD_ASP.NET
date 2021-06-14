using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project04_Auth_CRUD_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project04_Auth_CRUD_ASP.NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BarberModel> Barbers { get; set; }
        public DbSet<PriceModel> Prices { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
