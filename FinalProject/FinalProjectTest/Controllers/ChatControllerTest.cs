using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.Controllers
{

    [TestClass]
    public class ChatControllerTest
    {
        private ChatController chatController;
        private readonly UserManager<IdentityUser> _userManager;

        

        [TestMethod]
        public void Get_Chat_With_Id()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Chat").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            chatController = new ChatController(context, _userManager);
            seed(context);
            ChatModel chat = chatController.Get(1)[0];
            ChatModel expected = new ChatModel()
            { Id = 1, To = "test", UserId = "test2" };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected.Id, chat.Id);
        }

        public void seed(ApplicationDbContext context)
        {
            var all = new[]
            {
                 new ChatModel(){ Id = 3, To = "123", UserId = "321" },
                 new ChatModel(){ Id = 1, To = "747", UserId = "1" },
                 new ChatModel(){ Id = 5, To = "896", UserId = "2" },
                 new ChatModel(){ Id = 4, To = "999", UserId = "22" }
        };
            context.Chats.AddRange(all);
            context.SaveChanges();
        }
    }
}
