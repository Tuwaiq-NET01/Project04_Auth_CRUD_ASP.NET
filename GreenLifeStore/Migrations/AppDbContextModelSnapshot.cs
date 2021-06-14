﻿// <auto-generated />
using GroceryStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GreenLifeStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GreenLifeStore.Models.BranchModel", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchId");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            Address = "Riyadh",
                            Name = "Norah Grocery"
                        },
                        new
                        {
                            BranchId = 2,
                            Address = "Dammam",
                            Name = "Norah Grocery"
                        },
                        new
                        {
                            BranchId = 3,
                            Address = "Jeddah",
                            Name = "Norah Grocery"
                        });
                });

            modelBuilder.Entity("GreenLifeStore.Models.ProductModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductDetails")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/170x165/9df78eab33525d08d6e5fb8d27136e95/1/3/132.jpg",
                            Name = "Apple",
                            Price = 1.5f,
                            ProductDetails = "Organic Apple"
                        },
                        new
                        {
                            ProductId = 2,
                            Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/340x330/9df78eab33525d08d6e5fb8d27136e95/o/r/orange-2.jpg",
                            Name = "Orange",
                            Price = 1.5f,
                            ProductDetails = "Orgainc Orange"
                        },
                        new
                        {
                            ProductId = 3,
                            Image = "https://www.othaimmarkets.com/media/catalog/product/cache/4/small_image/340x330/9df78eab33525d08d6e5fb8d27136e95/5/0/500_0.jpg",
                            Name = "Banana",
                            Price = 3.5f,
                            ProductDetails = "Organic Banana"
                        });
                });

            modelBuilder.Entity("GreenLifeStore.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "Jeddah, Al Marwah, Saeed Albasri street",
                            Email = "norah@outlook.sa",
                            FirstName = "Norah",
                            LastName = "Almutairi",
                            Password = "Nora12345",
                            Phone = "0534355512"
                        },
                        new
                        {
                            UserId = 2,
                            Address = "Riyadh, Al Narjis, Alsalamah street",
                            Email = "Maha@outlook.sa",
                            FirstName = "Maha",
                            LastName = "Alzahrani",
                            Password = "mo6718939",
                            Phone = "0565355519"
                        },
                        new
                        {
                            UserId = 3,
                            Address = "Dammam, Al Rawdah, Malik Ibn Jubair street",
                            Email = "Mona@outlook.sa",
                            FirstName = "Mona",
                            LastName = "Alghamdi",
                            Password = "Moon54321",
                            Phone = "0535366514"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
