using System;
using Microsoft.EntityFrameworkCore;
using MaNodelz.Controllers;
using MaNodelz.Models;
using System.Linq;
using Xunit;
using MaNodelz.Data;

namespace MaNodelzTest.Test
{
    public class FoodControllerTest
    {
        [Fact]
        public void DoesFoodControllerReturnFoods()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MaNodelz")
                .Options;

            var context = new ApplicationDbContext(options);
            Seed(context);

            var query = new FoodController(context);

            var result = query.Index();

            //Assert.Equal(2,result.Count);
        }

        private void Seed(ApplicationDbContext context)
        {
            var food = new[]
            {
                new FoodModel { Id = 1, FoodName = "Naruto's Nodelz", FoodDescription = "Hokagy's way of making nodelz", FoodImage = "https://favy-inbound-singapore.s3.amazonaws.com/uploads/topic_item/image/76335/retina_tokyo_style_ramen_with_Naruto.jpg", FoodType="Nodelz",FoodTobePrepared=new TimeSpan(00,20,10) },
                new FoodModel { Id = 2, FoodName = "Nodelz", FoodDescription = "Hokagy's way of making nodelz", FoodImage = "https://favy-inbound-singapore.s3.amazonaws.com/uploads/topic_item/image/76335/retina_tokyo_style_ramen_with_Naruto.jpg", FoodType="Nodelz",FoodTobePrepared=new TimeSpan(00,20,10) }, 
            };
            context.Food.AddRange(food);
            context.SaveChanges();


         }
          
        }
    }

