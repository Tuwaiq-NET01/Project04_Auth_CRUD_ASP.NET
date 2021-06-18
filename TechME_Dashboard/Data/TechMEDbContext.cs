using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechME_Dashboard.Models;

namespace TechME_Dashboard.Data
{
    public class TechMEDbContext : IdentityDbContext
    {
        public TechMEDbContext(DbContextOptions<TechMEDbContext> options)
            : base(options)
        {
             
        }
        public DbSet<ContactModel> ContactUs { get; set; }
        public DbSet<CourseModel> Course { get; set; }
        public DbSet<InstructorModel> Instructor { get; set; }
        public DbSet<TraineeModel> Trainee { get; set; }

    }
}

