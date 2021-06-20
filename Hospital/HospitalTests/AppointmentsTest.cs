using Hospital.Controllers;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HospitalTests
{
    public class Tests
    {
        private ApplicationDbContext _db;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("HospitalDatabase").Options;
            _db = new ApplicationDbContext(options);

            DateTime date = new DateTime(2021, 06, 25, 0, 0, 0);
            DateTime time = new DateTime(0001, 01, 01, 16, 30, 0);
            var appointment1 = new Appointment
            {
                Id = 12,
                PatientId = 1,
                DoctorId = 4,
                Speciality = "Dentist",
                Date = date,
                Time = time

            };

            this._db.Appointments.Add(appointment1);
            this._db.SaveChanges();
        }

        [Test]
        public void Test1()
        {
            var controller = new Appointments(this._db);
            var result = controller.Index() as ViewResult;
            var appointments = result.ViewData["Appointments"] as List<Appointment>;

            Assert.AreEqual(appointments[0].Speciality, "Dentist");
            Assert.Pass();
        }
    }
}