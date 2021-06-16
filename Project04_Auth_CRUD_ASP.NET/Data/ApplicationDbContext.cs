using Microsoft.AspNetCore.Identity;
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
        public DbSet<TimeModel> Times { get; set; }
        public DbSet<PriceModel> Prices { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TimeModel>().HasData(new TimeModel { Id = Guid.NewGuid(), Value = "Morning" });
            modelBuilder.Entity<TimeModel>().HasData(new TimeModel { Id = Guid.NewGuid(), Value = "Afternoon" });
            modelBuilder.Entity<TimeModel>().HasData(new TimeModel { Id = Guid.NewGuid(), Value = "Evening" });
            modelBuilder.Entity<TimeModel>().HasData(new TimeModel { Id = Guid.NewGuid(), Value = "Midnight" });
        }
        public DbSet<Project04_Auth_CRUD_ASP.NET.Models.ReservationModel> ReservationModel { get; set; }
    }
}
