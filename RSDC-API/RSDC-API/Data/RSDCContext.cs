using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RSDC_API.Data
{
    public class RSDCContext : IdentityDbContext
    {
        public virtual DbSet<Member> Members {get;set;}
        public virtual DbSet<Coach> Coaches {get;set;}
        public virtual DbSet<Type> Types {get;set;}
        public virtual DbSet<Store> Stores {get;set;}
        public virtual DbSet<Tournament> Tournaments {get;set;}

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>().Property(r => r.Email).IsRequired();
            modelBuilder.Entity<Coach>().Property(r => r.Email).IsRequired();

            modelBuilder.Entity<Type>().HasData(new Type { Id = 1, Fee = 2500, DivingType = "Scuba Diving" });
            modelBuilder.Entity<Type>().HasData(new Type { Id = 2, Fee = 2000, DivingType = "Free Diving" });
            modelBuilder.Entity<Type>().HasData(new Type { Id = 3, Fee = 1500, DivingType = "Swimming" });

            modelBuilder.Entity<Coach>().HasData(new Coach { Id = 1, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" });

            modelBuilder.Entity<Member>().HasData(new Member { Id = 1, FirstName = "Ali", LastName = "Kalu", Username = "AliKalu", Email = "Ali@KAlu", Password = "Ali@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png", CoachId = 1, TypeId = 1 });

            modelBuilder.Entity<Tournament>().HasData(new Tournament { Id = 1, TourName = "800m free swimming", Year = "2021", TourType = "Swimming", MemberId = 1 });

            modelBuilder.Entity<Store>().HasData(new Store { Id = 1, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 45.50, TypeId = 1 });
            modelBuilder.Entity<Store>().HasData(new Store { Id = 2, Title = "Suit", Image = "https://www.scubastore.com/l/13737/137371573/aqualung-fusion-bullet-air.jpg", Description = "Aqualung Fusion Bullet Air", Price = 4500.50, TypeId = 1 });
            modelBuilder.Entity<Store>().HasData(new Store { Id = 3, Title = "Suit", Image = "https://www.scubastore.com/f/13796/137963780/typhoon-quantum-lady.jpg", Description = "Typhoon Quantum Lady", Price = 4000, TypeId = 2 });
            modelBuilder.Entity<Store>().HasData(new Store { Id = 4, Title = "Belts", Image = "https://www.scubastore.com/f/12/127213/seac-weight-belt-stainless-steel.jpg", Description = "SEAC Weight Belt Stainless Steel", Price = 40.50, TypeId = 2 });

        }

        public RSDCContext(DbContextOptions<RSDCContext> options)
            : base(options)
        {    
        }

    }
}