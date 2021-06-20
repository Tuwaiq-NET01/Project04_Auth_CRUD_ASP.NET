using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.Controllers
{
    [TestClass]
    public class MessageContrillerTest
    {
        private MessageController messageController;



        [TestMethod]
        public void Get_Msg_With_Id()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Msg").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            messageController = new MessageController(context);
            seed(context);
            MessageModel msg = messageController.Get(1)[0];
            MessageModel expected = new MessageModel()
            { Id = 3, ChatId = 1, UserId = "321" };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected.UserId, msg.UserId);
        }

        public void seed(ApplicationDbContext context)
        {
            var all = new[]
            {
                 new MessageModel(){ Id = 3, ChatId = 1, UserId = "321" }
        };
            context.Messages.AddRange(all);
            context.SaveChanges();
        }
    }
}
