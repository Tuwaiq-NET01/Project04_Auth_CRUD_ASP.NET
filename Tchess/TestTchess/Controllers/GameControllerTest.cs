using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Tchess.Data;
using Tchess.Controllers;
using Tchess.Models;


namespace TestTchess.Controllers
{
    public class Tests
    {
        private GameController gameController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Tchess").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            gameController = new GameController(context);
            seed(context);
        }

        [Test]
        public void Get_Game_With_Id()
        {
            Game game = gameController.GetGameID(2);
            Game expected = new Game()
                {Id = 2, Moves = "asd", NumMoves = "44", Profile = null, ProfileId = 2, Winner = "hassan"};
            Assert.AreEqual(expected.Id, game.Id);
        }

        [Test]
        public void Get_Game_With_Id_Exception()
        {
            Assert.Throws<NullReferenceException>((() => gameController.GetGameID(99)));
        }
        
        [Test]
        public void Get_All_Games()
        {
            var games = gameController.GetAllGames();
            Assert.AreEqual(5,games.Count);
        }
        [Test]
        public void Delete_Game_With_Id()
        {
            gameController.DeleteGame(4);
            var gamesss = gameController.GetAllGames();
            Assert.AreEqual(4,gamesss.Count);
        }
        [Test]
        public void Delete_Game_With_Id_Exception()
        {
            Assert.Throws<NullReferenceException>((() => gameController.DeleteGame(99)));
        }
        [Test]
        public void Edit_Game_With_Id()
        {
            Game g = gameController.GetAllGames()[2];
            g.Winner = "Nouf";
            gameController.Edit_Game(g);
            Assert.AreEqual("Nouf",gameController.GetAllGames()[2].Winner);
        }
        [Test]
        public void Edit_Game_With_Id_Exception()
        {
            Game g =new Game() {Id = 9999, Moves = "asd", NumMoves = "44", Profile = null, ProfileId = 2, Winner = "hassan"};
            Assert.Throws<NullReferenceException>((() => gameController.Edit_Game(g)));
        }
        [Test]
        public void Create_Game()
        {
            Game g = new Game() {Id = 6, Moves = "ss", NumMoves = "11", Profile = null, ProfileId = 3, Winner = "Nouf"};
            gameController.create_Game(g);
            Assert.AreEqual(6,gameController.GetAllGames().Count);
        }

        public void seed(ApplicationDbContext context)
        {
            var games = new[]
            {
                new Game() {Id = 1, Moves = "ascd", NumMoves = "10", Profile = null, ProfileId = 1, Winner = "hassan"},
                new Game() {Id = 2, Moves = "asd", NumMoves = "44", Profile = null, ProfileId = 2, Winner = "hassan"},
                new Game() {Id = 3, Moves = "www", NumMoves = "33", Profile = null, ProfileId = 2, Winner = "hassan"},
                new Game() {Id = 4, Moves = "sss", NumMoves = "22", Profile = null, ProfileId = 2, Winner = "hassan"},
                new Game() {Id = 5, Moves = "xx", NumMoves = "11", Profile = null, ProfileId = 3, Winner = "hassan"}
            };
            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
}