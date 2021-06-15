using Coffee.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;


namespace Coffee.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seeding

            modelBuilder.Entity<Bean>()
                .HasData(new Bean
                {
                    ID = 1,
                    Name="Tuwaiq",
                    Image= "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/37_600x.png?v=1621461202",
                    Type="Washed",
                    Country= "Colombia",
                    RoasterID=2
                });

            modelBuilder.Entity<Bean>()
               .HasData(new Bean
               {
                   ID = 2,
                   Name = "Qiddiya",
                   Image = "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/36_b624fe7b-9f13-4c19-bf4b-3f8de041b668_1200x.png?v=1621461554",
                   Type = "Washed",
                   Country = "Guatemala",
                   RoasterID=2
               });
            modelBuilder.Entity<Bean>()
              .HasData(new Bean
              {
                  ID = 3,
                  Name = "El Salvador Baraona",
                  Image = "https://camelstep.com/media/catalog/product/cache/cb1cf9ef08bd8ac078031d7ecd205277/_/-/_-__1_8.jpg",
                  Type = "Natural",
                  Country = "El Salvador",
                  RoasterID=4
              });
            modelBuilder.Entity<Bean>()
           .HasData(new Bean
           {
               ID = 4,
               Name = "Ethiopia Ariti",
               Image = "https://camelstep.com/media/catalog/product/cache/cb1cf9ef08bd8ac078031d7ecd205277/_/-/_-__1_5.jpg",
               Type = "Natural",
               Country = "Ethiopia",
               RoasterID=4
           });
              modelBuilder.Entity<Bean>()
           .HasData(new Bean
           {
               ID = 5,
               Name = "Mananasi Espresso",
               Image = "https://cdn.salla.sa/WyvX/PJUADylqF3BnEfwx7oqnmt8WwNV721uy1aaNc829.jpg",
               Type = "Natural",
               Country = "Uganda",
               RoasterID=3
           });
              modelBuilder.Entity<Bean>()
           .HasData(new Bean
           {
               ID = 6,
               Name = "Chelbesa",
               Image = "https://octave.coffee/wp-content/uploads/2021/04/chilbisa.jpg",
               Type = "Natural",
               Country = "Ethiopia",
               RoasterID=1
           });
        

        modelBuilder.Entity<Roastery>()
           .HasData(new Roastery
           {
           ID=1,
           Name= "Kiffa Roaster",
           Image= "https://media.zid.store/cdbbc706-61b2-4d93-9791-9f65743fe34b/ac8422ff-c987-4f26-8185-8c5cfe0464b9.jpeg",
           Location= "Maddinah",
           Rate = 4.4,
           });
            modelBuilder.Entity<Roastery>()
         .HasData(new Roastery
         {
             ID = 2,
             Name = "Arriyadh Roaster",
             Image = "https://pbs.twimg.com/profile_images/1313161853045035008/womhVuch_400x400.jpg",
             Location = "Riyadh",
             Rate = 4.6,
         });
                     modelBuilder.Entity<Roastery>()
         .HasData(new Roastery
         {
             ID = 3,
             Name = "Suwaa Roaster",
             Image = "https://modernsupply.com.sa/wp-content/uploads/2021/03/31.jpg",
             Location = "Jeddah",
             Rate = 4.5,
         });
                     modelBuilder.Entity<Roastery>()
         .HasData(new Roastery
         {
             ID = 4,
             Name = "Camel Step Roaster",
             Image = "http://cdn.shopify.com/s/files/1/0257/0046/6776/collections/image_2d2722a5-3abe-4199-b964-5859ca7b790c_1200x1200.png?v=1584446917",
             Location = "Khobar",
             Rate = 4.3,
         });

            modelBuilder.Entity<Tool>()
         .HasData(new Tool
         {
             ID = 1,
             Name = "TASH Steamer Jug Navy Blue Sharp",
             Image = "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/DSC2671_1000x.jpg?v=1599727765",
             Description= @"380ml black stainless steel steam jug
             Smooth design and tapered tip for easy drawing and pour control
             in blue"
         });
           modelBuilder.Entity<Tool>()
         .HasData(new Tool
         {
             ID = 2,
             Name = "Tach port filter exposed",
             Image = "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/DSC3839_1000x.jpg?v=1599727217",
             Description= @"Stainless steel exposed port filter with black rod Size 54 mm
             Compatible with Breville Barista Express - Sage Machines"
         });
                modelBuilder.Entity<Tool>()
         .HasData(new Tool
         {
             ID = 3,
             Name = "Tach coffee dispenser",
             Image = "https://cdn.shopify.com/s/files/1/0028/9085/8569/products/Artboard_7_21f579be-9c5b-413e-8612-6b47f6e76df1.jpg?v=1599734667",
             Description= @"The Tach Coffee Dispenser The espresso surface dispenser allows for the desired depth to be adjusted to ensure perfect dispensing every time.
              53 mm in size"
         });
        }

        public DbSet<Bean> Beans { get; set; }
        public DbSet<Roastery> Roasteries { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }





    }
}
