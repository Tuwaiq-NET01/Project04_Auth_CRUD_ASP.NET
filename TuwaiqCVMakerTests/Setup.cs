using System;
using System.Collections.Generic;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using TuwaiqCVMaker.Data;
using TuwaiqCVMaker.Models;

namespace TuwaiqCVMakerTests
{
    public class Setup
    {
        private ApplicationDbContext _db;
        
        public ApplicationDbContext Database(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName).Options;
            this._db = new ApplicationDbContext(options, Options.Create(new OperationalStoreOptions()));
            
            SeedUsers();
            SeedResumes();
            SeedBills();
            
            return this._db;
        }

        private void SeedUsers()
        {
            var user1 = new ApplicationUser
            {
                Id = "ahmed",
                UserName = "Ahmed Alzubaidi",
                Email = "Ahmed.Tuwaiq@Tuwaiq.edu.sa"
            };
            var user2 = new ApplicationUser
            {
                Id = "turki",
                UserName = "Turki Alqurashi",
                Email = "Turki.Alqurashi@Tuwaiq.edu.sa"
            };

            this._db.Users.Add(user1);
            this._db.Users.Add(user2);
            this._db.SaveChanges();
        }

        private void SeedResumes()
        {
            var resume1 = new Resume
            {
                Id = 1,
                UserId = "ahmed",
                Title = "Backend dev",
                Template = "Template1",
                Name = "Ahmed Alzubaidi",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Id = 1,
                        ResumeId = 1,
                        Name = "C#"
                    },
                    new Skill
                    {
                        Id = 2,
                        ResumeId = 1,
                        Name = "Java"
                    }
                }
            };
            
            var resume2 = new Resume
            {
                Id = 2,
                UserId = "turki",
                Title = "Backend dev",
                Template = "Template2",
                Name = "Turki Alqurashi",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Id = 3,
                        ResumeId = 2,
                        Name = "C#"
                    },
                    new Skill
                    {
                        Id = 4,
                        ResumeId = 2,
                        Name = "C++"
                    },
                    new Skill
                    {
                        Id = 5,
                        ResumeId = 2,
                        Name = "Ahmed Language"
                    }
                }
            };

            this._db.Resumes.Add(resume1);
            this._db.Resumes.Add(resume2);
            this._db.SaveChanges();
        }
        
        private void SeedBills()
        {
            var bill1 = new Bill
            {
                Id = 1,
                UserId = "ahmed",
                Amount = 1000m,
                Tax = 500m,
                Total = 1500m
            };
            
            var bill2 = new Bill
            {
                Id = 2,
                UserId = "ahmed",
                Amount = 1000m,
                Tax = 500m,
                Total = 1500m
            };

            this._db.Bills.Add(bill1);
            this._db.Bills.Add(bill2);
            this._db.SaveChanges();
        }
    }
}