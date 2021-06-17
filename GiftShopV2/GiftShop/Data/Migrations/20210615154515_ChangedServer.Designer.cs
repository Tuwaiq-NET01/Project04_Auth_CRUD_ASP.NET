﻿// <auto-generated />
using System;
using GiftShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiftShop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210615154515_ChangedServer")]
    partial class ChangedServer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GiftShop.Models.BalloonModel", b =>
                {
                    b.Property<int>("BalloonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BalloonImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BalloonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BalloonPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BalloonId");

                    b.ToTable("Balloons");

                    b.HasData(
                        new
                        {
                            BalloonId = 301,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/0/0/0013475_gold-helium-latex-balloons-6_1.jpeg",
                            BalloonName = "Gold Helium Latex Balloons (6)",
                            BalloonPrice = 44.00m
                        },
                        new
                        {
                            BalloonId = 302,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0007414_multi-color-helium-latex-balloons-12_2.jpeg",
                            BalloonName = "Multi-Color Helium Latex Balloons (12)",
                            BalloonPrice = 87.00m
                        },
                        new
                        {
                            BalloonId = 303,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0013645_balloon-bouquet-lime-green_2.jpeg",
                            BalloonName = "Balloon Bouquet (Lime Green)",
                            BalloonPrice = 77.00m
                        },
                        new
                        {
                            BalloonId = 304,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0002077_rainbow-surprise_1.jpeg",
                            BalloonName = "Rainbow Surprise Balloon Bouquet",
                            BalloonPrice = 66.00m
                        },
                        new
                        {
                            BalloonId = 305,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0019413_whats-your-number_1.jpeg",
                            BalloonName = "Numeric Balloons",
                            BalloonPrice = 60.00m
                        },
                        new
                        {
                            BalloonId = 306,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0013665_balloon-bouquet-red-black_2.jpeg",
                            BalloonName = "Balloon Bouquet (Red & Black)",
                            BalloonPrice = 148.00m
                        },
                        new
                        {
                            BalloonId = 307,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/9/_/9_2_3.jpg",
                            BalloonName = "8 Chrome Latex Balloons",
                            BalloonPrice = 116.00m
                        },
                        new
                        {
                            BalloonId = 308,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/f072df2045c653777a2d5e7679b7d2b6/7/_/7_1_2_3.jpg",
                            BalloonName = "6 Green Chrome Latex Balloons",
                            BalloonPrice = 87.00m
                        },
                        new
                        {
                            BalloonId = 309,
                            BalloonImage = "https://www.joigifts.com/pub/media/catalog/product/cache/dcb175787b4bdf31b2110d086ed3c9ff/0/0/0007416_pink-helium-latex-balloons-6_2.jpeg",
                            BalloonName = "Pink Helium Latex Balloons (6)",
                            BalloonPrice = 44.00m
                        });
                });

            modelBuilder.Entity("GiftShop.Models.FlowerModel", b =>
                {
                    b.Property<int>("FlowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlowerImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlowerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FlowerPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FlowerId");

                    b.ToTable("Flowers");

                    b.HasData(
                        new
                        {
                            FlowerId = 101,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637447438702232017.jpg?w=500",
                            FlowerName = "Pink Dust",
                            FlowerPrice = 310.50m
                        },
                        new
                        {
                            FlowerId = 102,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637375823162633954.jpg?w=500",
                            FlowerName = "Breeze",
                            FlowerPrice = 322.00m
                        },
                        new
                        {
                            FlowerId = 103,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637467433600235841.jpg?w=500",
                            FlowerName = "Love Mix",
                            FlowerPrice = 360.00m
                        },
                        new
                        {
                            FlowerId = 104,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637368837979802520.jpg?width=600",
                            FlowerName = "Sleek Bouquet",
                            FlowerPrice = 200.00m
                        },
                        new
                        {
                            FlowerId = 105,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637363759603959215.jpg?width=600",
                            FlowerName = "35 Roses hand bouquet III",
                            FlowerPrice = 280.00m
                        },
                        new
                        {
                            FlowerId = 106,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637363761825283068.jpg?width=600",
                            FlowerName = "50 Roses hand bouquet II",
                            FlowerPrice = 414.00m
                        },
                        new
                        {
                            FlowerId = 107,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637448274952847223.jpg?width=600",
                            FlowerName = "White and Yellow Roses",
                            FlowerPrice = 230.50m
                        },
                        new
                        {
                            FlowerId = 108,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637503588358822359.jpg?width=600",
                            FlowerName = "Pink Roses",
                            FlowerPrice = 312.00m
                        },
                        new
                        {
                            FlowerId = 109,
                            FlowerImage = "https://floward.imgix.net/web/Files/thumPro/637502715042825399.jpg?width=600",
                            FlowerName = "Purple Tulips",
                            FlowerPrice = 430.00m
                        });
                });

            modelBuilder.Entity("GiftShop.Models.SweetModel", b =>
                {
                    b.Property<int>("SweetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SweetImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SweetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SweetPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SweetId");

                    b.ToTable("Sweets");

                    b.HasData(
                        new
                        {
                            SweetId = 201,
                            SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20201205120230/delicious-fudge-cake_1.jpg",
                            SweetName = "Delicious Fudge Cake 4 Portion",
                            SweetPrice = 99.00m
                        },
                        new
                        {
                            SweetId = 202,
                            SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20201205120228/red-velvet-berry-cream-cake_1.jpg",
                            SweetName = "Red Velvet Berry Cream Cake 6 Portion",
                            SweetPrice = 129.00m
                        },
                        new
                        {
                            SweetId = 203,
                            SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20210402160935/creamy-red-velvet-cake_1.jpg",
                            SweetName = "Creamy Red Velvet Cake Half Kg",
                            SweetPrice = 109.00m
                        },
                        new
                        {
                            SweetId = 204,
                            SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20201205120229/crunchy-chocolate-hazelnut-cake_1.jpg",
                            SweetName = "Crunchy Chocolate Hazelnut Cake 4 Portion",
                            SweetPrice = 119.00m
                        },
                        new
                        {
                            SweetId = 205,
                            SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20210402160934/tales-of-taste-ice-cream-cone-cake_1.jpg",
                            SweetName = "Tales of Taste Ice Cream Cone Cake",
                            SweetPrice = 278.00m
                        },
                        new
                        {
                            SweetId = 206,
                            SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20210202110031/heavenly-chocolate-cream-cake_1.jpg",
                            SweetName = "Heavenly Chocolate Cream Cake Half Kg",
                            SweetPrice = 119.00m
                        },
                        new
                        {
                            SweetId = 207,
                            SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20201215142751/the-gentleman-theme-cake_1.jpg",
                            SweetName = "The Gentleman Theme Cake 8 Portions Vanilla",
                            SweetPrice = 279.00m
                        },
                        new
                        {
                            SweetId = 208,
                            SweetImage = "https://sa-i1.fnp.com//images/pr/l/v20210526180156/candy-topped-chocolate-cake_1.jpg",
                            SweetName = "Candy Topped Chocolate Cake Half Kg",
                            SweetPrice = 129.00m
                        },
                        new
                        {
                            SweetId = 209,
                            SweetImage = "https://sa-i1.fnp.com/images/pr/l/v20201215142740/princess-theme-cake_1.jpg",
                            SweetName = "Princess Theme Cake 12 Portions Vanilla",
                            SweetPrice = 399.00m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaim");
                });
#pragma warning restore 612, 618
        }
    }
}
