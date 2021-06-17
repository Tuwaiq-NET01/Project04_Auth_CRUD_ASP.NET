using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExamApplication.Models;

namespace ExamApplication.Data
{
    public class MyDbContext : IdentityDbContext
    {
        private string _db;
        public MyDbContext(String conntectionString = "Data source=DESKTOP-SP2UVRT\\SQLEXPRESS01; initial catalog= ExamDb; Integrated security= true") : base()
        {
            _db = conntectionString;
        }
        public MyDbContext(DbContextOptions existingConnection, bool contextOwnConnection) : base(existingConnection)
        {

        }

        public MyDbContext() : base()
        {

        }
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var ConnectionString = configuration["ApplicationSettings:DevelopmentalContext"];
                optionsBuilder.UseSqlServer(ConnectionString);

            }

        }

        public DbSet<Questions> Question { get; set; }
        public DbSet<Answers> Answer { get; set; }
        public DbSet<Admins> Admin { get; set; }
        public DbSet<Students> Student { get; set; }
    }
}
