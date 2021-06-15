using HjtProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HjtProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<InstructorModel> Instructors { get; set; }
        public DbSet<OrganizationModel> Organizations { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
    }
}
