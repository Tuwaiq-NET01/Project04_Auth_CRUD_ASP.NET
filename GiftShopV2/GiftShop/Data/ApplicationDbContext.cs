using GiftShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public DbSet<IdentityUser> IdentityUser { get; set; }

        public DbSet<FlowerModel> Flowers { get; set; }
        public DbSet<SweetModel> Sweets { get; set; }
        public DbSet<BalloonModel> Balloons { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(p => new { p.Id });

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 101, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637447438702232017.jpg?w=500", FlowerName = "Pink Dust", FlowerPrice = 310.50m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 102, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637375823162633954.jpg?w=500", FlowerName = "Breeze", FlowerPrice = 322.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 103, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637467433600235841.jpg?w=500", FlowerName = "Love Mix", FlowerPrice = 360.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 104, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637368837979802520.jpg?width=600", FlowerName = "Sleek Bouquet", FlowerPrice = 200.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 105, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637363759603959215.jpg?width=600", FlowerName = "35 Roses hand bouquet III", FlowerPrice = 280.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 106, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637363761825283068.jpg?width=600", FlowerName = "50 Roses hand bouquet II", FlowerPrice = 414.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 107, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637448274952847223.jpg?width=600", FlowerName = "White and Yellow Roses", FlowerPrice = 230.50m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 108, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637503588358822359.jpg?width=600", FlowerName = "Pink Roses", FlowerPrice = 312.00m });
            modelBuilder.Entity<FlowerModel>().HasData(new FlowerModel { FlowerId = 109, FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637502715042825399.jpg?width=600", FlowerName = "Purple Tulips", FlowerPrice = 430.00m });


            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 201, SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20201205120230/delicious-fudge-cake_1.jpg", SweetName = "Delicious Fudge Cake 4 Portion", SweetPrice = 99.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 202, SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20201205120228/red-velvet-berry-cream-cake_1.jpg", SweetName = "Red Velvet Berry Cream Cake 6 Portion", SweetPrice = 129.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 203, SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20210402160935/creamy-red-velvet-cake_1.jpg", SweetName = "Creamy Red Velvet Cake Half Kg", SweetPrice = 109.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 204, SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20201205120229/crunchy-chocolate-hazelnut-cake_1.jpg", SweetName = "Crunchy Chocolate Hazelnut Cake 4 Portion", SweetPrice = 119.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 205, SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20210402160934/tales-of-taste-ice-cream-cone-cake_1.jpg", SweetName = "Tales of Taste Ice Cream Cone Cake", SweetPrice = 278.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 206, SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20210202110031/heavenly-chocolate-cream-cake_1.jpg", SweetName = "Heavenly Chocolate Cream Cake Half Kg", SweetPrice = 119.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 207, SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20201215142751/the-gentleman-theme-cake_1.jpg", SweetName = "The Gentleman Theme Cake 8 Portions Vanilla", SweetPrice = 279.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 208, SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20210526180156/candy-topped-chocolate-cake_1.jpg", SweetName = "Candy Topped Chocolate Cake Half Kg", SweetPrice = 129.00m });
            modelBuilder.Entity<SweetModel>().HasData(new SweetModel { SweetId = 209, SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20201215142740/princess-theme-cake_1.jpg", SweetName = "Princess Theme Cake 12 Portions Vanilla", SweetPrice = 399.00m });


            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 301, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/0/0/0013475_gold-helium-latex-balloons-6_1.jpeg", BalloonName = "Gold Helium Latex Balloons (6)", BalloonPrice = 44.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 302, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0007414_multi-color-helium-latex-balloons-12_2.jpeg", BalloonName = "Multi-Color Helium Latex Balloons (12)", BalloonPrice = 87.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 303, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0013645_balloon-bouquet-lime-green_2.jpeg", BalloonName = "Balloon Bouquet (Lime Green)", BalloonPrice = 77.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 304, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0002077_rainbow-surprise_1.jpeg", BalloonName = "Rainbow Surprise Balloon Bouquet", BalloonPrice = 66.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 305, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0019413_whats-your-number_1.jpeg", BalloonName = "Numeric Balloons", BalloonPrice = 60.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 306, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0013665_balloon-bouquet-red-black_2.jpeg", BalloonName = "Balloon Bouquet (Red & Black)", BalloonPrice = 148.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 307, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/9/_/9_2_3.jpg", BalloonName = "8 Chrome Latex Balloons", BalloonPrice = 116.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 308, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/7/_/7_1_2_3.jpg", BalloonName = "6 Green Chrome Latex Balloons", BalloonPrice = 87.00m });
            modelBuilder.Entity<BalloonModel>().HasData(new BalloonModel { BalloonId = 309, BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0007416_pink-helium-latex-balloons-6_2.jpeg", BalloonName = "Pink Helium Latex Balloons (6)", BalloonPrice = 44.00m });

        }
    }
}
