using Final_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ParkingModel> Parkings { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<ReservationsModel> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AdminModel>().HasData(new AdminModel
            {
                Id = 1,
                Name = "shahad",
                Email = "shahad1_cs@hotmail.com",
                Password = "1234",
                Phone_Number = 0553388292,

            });
            // Data Parking Table
            modelBuilder.Entity<ParkingModel>().HasData(new ParkingModel
            {
                Id = 1,
                AdminId = 1
            });
            modelBuilder.Entity<ParkingModel>().HasData(new ParkingModel
            {
                Id = 2,
                AdminId = 1
            });
            modelBuilder.Entity<ParkingModel>().HasData(new ParkingModel
            {
                Id = 3,
                AdminId = 1
            });
            modelBuilder.Entity<ParkingModel>().HasData(new ParkingModel
            {
                Id = 4,
                AdminId = 1
            });
            modelBuilder.Entity<ParkingModel>().HasData(new ParkingModel
            {
                Id = 5,
                AdminId = 1
            });
            modelBuilder.Entity<ParkingModel>().HasData(new ParkingModel
            {
                Id = 6,
                AdminId = 1
            });


        }

    }
}