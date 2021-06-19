using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationManagement.Data;
using System.ComponentModel.DataAnnotations;
using HotelReservationManagement.Models;
using HotelReservationManagement.Controllers;


namespace HotelReservationManagementTest.Controller
{
    public class HotelsControllerTest
    {
        private HotelsController hotelsController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "HotelReservationManagement").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            hotelsController = new HotelsController(context);
            Seeding(context);
        }

        [Test]
        public void DoesCreateBook()
        {
            //Arrange
            HotelModel hotel = new HotelModel()
            {
                HotelId = 4,
                HotelImage = "https://images.unsplash.com/photo-1560200353-ce0a76b1d438?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NXx8aG90ZWxzfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=900&q=60",
                HotelName = "Arwa",
                City = "Riyadh",
                PhoneNumber = 11111,
                State = "Riyadh",
                ZipCode = "1123"
            };
            hotelsController.createHotel(hotel);
            //Assert
            Assert.AreEqual(expected: 4, actual: hotelsController.getAllHotels().Count);
        }


        //Function to test data
        public void Seeding(ApplicationDbContext context)
        {
            var hotels = new[]
            {
                new HotelModel
                {
                    HotelId = 1,
                    HotelImage = "https://images.unsplash.com/photo-1560200353-ce0a76b1d438?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NXx8aG90ZWxzfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=900&q=60",
                    HotelName = "Arwa",
                    City = "Riyadh",
                    PhoneNumber = 11111,
                    State = "Riyadh",
                    ZipCode = "1123"
                },

                new HotelModel
                {
                    HotelId = 2,
                    HotelImage = "https://images.unsplash.com/photo-1560200353-ce0a76b1d438?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NXx8aG90ZWxzfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=900&q=60",
                    HotelName = "Arwa",
                    City = "Riyadh",
                    PhoneNumber = 11111,
                    State = "Riyadh",
                    ZipCode = "1123"
                },

                new HotelModel
                {
                    HotelId = 3,
                    HotelImage = "https://images.unsplash.com/photo-1560200353-ce0a76b1d438?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NXx8aG90ZWxzfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=900&q=60",
                    HotelName = "Arwa",
                    City = "Riyadh",
                    PhoneNumber = 11111,
                    State = "Riyadh",
                    ZipCode = "1123"
                }
                };

            context.Hotels.AddRange(hotels);
            context.SaveChanges();

        }

    }

}

