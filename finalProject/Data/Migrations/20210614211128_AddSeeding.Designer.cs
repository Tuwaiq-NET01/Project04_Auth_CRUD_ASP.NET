﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using finalProject.Data;

namespace finalProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210614211128_AddSeeding")]
    partial class AddSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("finalProject.Models.CommentModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CoursesModelid")
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CoursesModelid");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CommentContent = "First comment here ",
                            course_id = 1
                        },
                        new
                        {
                            id = 2,
                            CommentContent = "second comment here ",
                            course_id = 1
                        },
                        new
                        {
                            id = 3,
                            CommentContent = "third comment here ",
                            course_id = 1
                        },
                        new
                        {
                            id = 4,
                            CommentContent = "First comment here ",
                            course_id = 2
                        });
                });

            modelBuilder.Entity("finalProject.Models.CoursesModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            id = 1,
                            subject = "Dot Net"
                        },
                        new
                        {
                            id = 2,
                            subject = "React"
                        },
                        new
                        {
                            id = 3,
                            subject = "Design patterns"
                        },
                        new
                        {
                            id = 4,
                            subject = "Unit testing"
                        });
                });

            modelBuilder.Entity("finalProject.Models.Files_UploadedModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoursesModelid")
                        .HasColumnType("int");

                    b.Property<int?>("StudentModelid")
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("student_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CoursesModelid");

                    b.HasIndex("StudentModelid");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            id = 1,
                            course_id = 1,
                            date = new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture One week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 2,
                            course_id = 1,
                            date = new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture tow week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 3,
                            course_id = 1,
                            date = new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture three week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 4,
                            course_id = 1,
                            date = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture four week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 5,
                            course_id = 1,
                            date = new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture five week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 6,
                            course_id = 2,
                            date = new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture One week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 7,
                            course_id = 2,
                            date = new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture tow week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 8,
                            course_id = 2,
                            date = new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture three week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 9,
                            course_id = 2,
                            date = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture four week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 10,
                            course_id = 2,
                            date = new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture five week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 11,
                            course_id = 3,
                            date = new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture One week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 12,
                            course_id = 3,
                            date = new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture tow week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 13,
                            course_id = 3,
                            date = new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture three week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 14,
                            course_id = 3,
                            date = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture four week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 15,
                            course_id = 3,
                            date = new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture five week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 16,
                            course_id = 4,
                            date = new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture One week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 17,
                            course_id = 4,
                            date = new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture tow week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 18,
                            course_id = 4,
                            date = new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture three week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 19,
                            course_id = 4,
                            date = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture four week 4",
                            student_id = 1
                        },
                        new
                        {
                            id = 20,
                            course_id = 4,
                            date = new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "Lecture five week 4",
                            student_id = 1
                        });
                });

            modelBuilder.Entity("finalProject.Models.InstructorModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            id = 1,
                            course_id = 1,
                            email = "sami@gmail.com",
                            name = "sami"
                        },
                        new
                        {
                            id = 2,
                            course_id = 1,
                            email = "ghada@gmail.com",
                            name = "ghada"
                        },
                        new
                        {
                            id = 3,
                            course_id = 2,
                            email = "lamyaa@gmail.com",
                            name = "lamyaa"
                        },
                        new
                        {
                            id = 4,
                            course_id = 4,
                            email = "fai@gmail.com",
                            name = "fai"
                        });
                });

            modelBuilder.Entity("finalProject.Models.StudentModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "Afra@gmail.com",
                            name = "Afra"
                        },
                        new
                        {
                            id = 2,
                            email = "Norah@mail.com",
                            name = "Norah"
                        },
                        new
                        {
                            id = 3,
                            email = "taif@mail.com",
                            name = "taif"
                        },
                        new
                        {
                            id = 4,
                            email = "sara@mail.com",
                            name = "sara"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("finalProject.Models.CommentModel", b =>
                {
                    b.HasOne("finalProject.Models.CoursesModel", null)
                        .WithMany("Comments")
                        .HasForeignKey("CoursesModelid");
                });

            modelBuilder.Entity("finalProject.Models.Files_UploadedModel", b =>
                {
                    b.HasOne("finalProject.Models.CoursesModel", null)
                        .WithMany("Files")
                        .HasForeignKey("CoursesModelid");

                    b.HasOne("finalProject.Models.StudentModel", null)
                        .WithMany("Files")
                        .HasForeignKey("StudentModelid");
                });

            modelBuilder.Entity("finalProject.Models.CoursesModel", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Files");
                });

            modelBuilder.Entity("finalProject.Models.StudentModel", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
