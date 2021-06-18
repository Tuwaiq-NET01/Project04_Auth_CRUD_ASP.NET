using _Platform_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _Platform_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Charity>().HasData(new Charity { Id = 1, CharityName = "إخاء", Description = "المؤسسة الخيرية لرعاية الأيتام", Image = "https://donatesstorage.blob.core.windows.net/all/3781.png", Url = "https://store.ekhaa.org.sa/" , UserId = "3396a74c-3bf8-4e01-b8fe-9a417777907d" });
            modelBuilder.Entity<News>().HasData(new News { Id = 1, Subject = "إخاء” و”وقت اللياقة” توقعان اتفاقية تمديد الشراكة لرعاية الأيتام", Description = "وقعت شركة «لجام للرياضة» المالك والمشغل لأندية «وقت اللياقة»، والمؤسسة الخيرية لرعاية الأيتام «إخاء» اتفاقية تمديد الشراكة", Image = "https://donatesstorage.blob.core.windows.net/all/3781.png", CharityId = 1 });
            modelBuilder.Entity<ambassador>().HasData(new ambassador { Id = 1, FirstName = "أمل", LastName = "المطيري", Description = "المؤسسة الخيرية لرعاية الأيتام", Email = "amalFreeh1@gmail.com", Image = "https://donatesstorage.blob.core.windows.net/all/3781.png", CharityId = 1 });
        }

        public DbSet<Charity> Charity { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ambassador> ambassador { get; set; }
    }
}
