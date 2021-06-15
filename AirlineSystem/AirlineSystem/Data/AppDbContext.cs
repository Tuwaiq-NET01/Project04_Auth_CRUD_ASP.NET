using AirlineSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PassengerModel> Passengers { get; set; }
        public DbSet<TripModel> Trips { get; set; }
        public DbSet<PlaneModel> Planes { get; set; }
        public DbSet<AirportModel> Airports { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //odelBuilder.Entity<TripModel>().HasMany(p=>p.Passangers).WithOne(t=>t.Trip).OnDelete(DeleteBehavior.Cascade);
        }

        }
}
