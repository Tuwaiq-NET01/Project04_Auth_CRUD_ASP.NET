using Microsoft.EntityFrameworkCore;
using RSDC_API;
using RSDC_API.Data;
using System;
using System.Linq;
using Xunit;

namespace RSDC_UnitTests
{
    public class CoachController
    {
        [Fact]
        public void GetAllCoaches()
        {
            var options = new DbContextOptionsBuilder<RSDCContext>()
                .UseInMemoryDatabase(databaseName: "GetAllTypes")
                .Options;

            var context = new RSDCContext(options);

            Seed(context);

            var query = new GetCoachQuery(context);

            var result = query.Execute();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetOneCoach()
        {
            var options = new DbContextOptionsBuilder<RSDCContext>()
                .UseInMemoryDatabase(databaseName: "GetOneTypes")
                .Options;

            var context = new RSDCContext(options);

            Seed(context);

            var query = new GetCoachQuery(context);

            var result = query.Execute();

            Assert.Equal("Adel", result.First().FirstName);
        }


        private void Seed(RSDCContext context)
        {
            var coaches = new[]
            {
                        new Coach { Id = 4, FirstName = "Adel", LastName = "Kalu", Username = "AdelKalu", Email = "Adel@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" },
                        new Coach { Id = 5, FirstName = "Ali", LastName = "Kalu", Username = "AliKalu", Email = "Ali@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" },
                        new Coach { Id = 6, FirstName = "Ahmed", LastName = "Kalu", Username = "AhmedKalu", Email = "Ahmed@KAlu", Password = "Adel@12345", Phone = 535555555, StartDate = System.DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), Gender = 'M', Image = "http://adel-kalu.com/index/images/icon.png" }
                    };

            context.Coaches.AddRange(coaches);
            context.SaveChanges();
        }
    }
}
