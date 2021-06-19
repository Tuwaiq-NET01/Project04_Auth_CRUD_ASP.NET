using HotelReservationManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<AdvanceUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<HotelModel> Hotels { get; set; }
       
        public DbSet<RoomModel> Rooms { get; set; }

        public DbSet<RoomBookingModel> RoomBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            base.OnModelCreating(modelBuilder);
        
        // configures one-to-many relationship
        modelBuilder.Entity<HotelModel>()
                .HasMany<RoomModel>(s => s.Rooms)
                .WithOne(r => r.Hotel)
                .OnDelete(DeleteBehavior.Cascade);

            /* modelBuilder.Entity<RoomBookingModel>()
                 .HasOne<RoomModel>(s => s.Room)
                 .WithMany(r => r.Bookings)
                 .HasForeignKey(q => q.RoomBookingId)
                 .OnDelete(DeleteBehavior.Cascade);*/

            /*modelBuilder.Entity<HotelModel>()
                .HasMany<>(s => s.Rooms)
                .WithOne(r => r.Hotel)
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}

