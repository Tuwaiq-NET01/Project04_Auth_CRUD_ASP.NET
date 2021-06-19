using System;
using Induction.Models;
using Microsoft.EntityFrameworkCore;

namespace Induction.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        
        // Adding tables to the database 
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MotivationModel> Motivations { get; set; }
        public DbSet<FactModel> Facts { get; set; }
        public DbSet<FlashCardModel> FlashCards { get; set; }
        public DbSet<QouteModel> Quotes { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<ChapterModel> Chapters { get; set; }
        public DbSet<ChapterChunkModel> ChapterChunks { get; set; }

        
        //Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data 
            
            //Users
            modelBuilder.Entity<UserModel>().HasData(new UserModel { Id = 1, Name = "Mansovic", Email="Mansoviic@gmail.com", Password="P@assWord123"}) ;
            modelBuilder.Entity<UserModel>().HasData(new UserModel { Id = 2, Name = "Mansovic2", Email="Mansoviic2@gmail.com", Password="P@assWord1232"}) ;
         
            // Motivations
            modelBuilder.Entity<MotivationModel>().HasData(new MotivationModel { id = 1, UserId = 2, CreatedAt = DateTime.Now, Body="Too many of us are not living our dreams because we are living our fears. —Les Brown"}) ;
            modelBuilder.Entity<MotivationModel>().HasData(new MotivationModel { id = 2, UserId = 1, CreatedAt = DateTime.Now, Body="If you really want the key to success, start by doing the opposite of what everyone else is doing. —Brad Szollose"}) ;
            // Facts
            modelBuilder.Entity<FactModel>().HasData(new FactModel { Id = 1, Body = "C# is OOP", Attachment= "https://www.w3schools.com/cs/cs_oop.asp", CreatedAt = DateTime.Now , UserId = 2}) ;
            modelBuilder.Entity<FactModel>().HasData(new FactModel { Id = 2, Body = "Tyndall effect- why the sky is blue", Attachment= "https://edu.rsc.org/resources/tyndall-effect-why-the-sky-is-blue/1877.article", CreatedAt = DateTime.Now , UserId = 1}) ;
            // Flash Cards 
            modelBuilder.Entity<FlashCardModel>().HasData(new FlashCardModel { id = 1, Question = "What is an abstract Keyword?", Answer= "The abstract keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class. "}) ;
            modelBuilder.Entity<FlashCardModel>().HasData(new FlashCardModel { id = 2, Question = "Delegate ", Answer= "A delegate is a reference type that can be used to encapsulate a named or an anonymous method."}) ;
            // Quotes
            modelBuilder.Entity<QouteModel>().HasData(new QouteModel { Id = 1, Body = "Stay Focused"}) ;
            modelBuilder.Entity<QouteModel>().HasData(new QouteModel { Id = 2, Body = "Keep it going"}) ;
          // Books 
            modelBuilder.Entity<BookModel>().HasData(new BookModel { Id = 1, Name = "C# in Depth, Fourth Edition" , Url = "https://www.oreilly.com/library/view/c-in-depth/9781617294532/"}) ;
            modelBuilder.Entity<BookModel>().HasData(new BookModel { Id = 2, Name = "Head First C#, 4th Editio" , Url = "https://www.oreilly.com/library/view/head-first-c/9781491976692/"}) ; 

            // Chapters
            modelBuilder.Entity<ChapterModel>().HasData(new ChapterModel { Id = 1, Title = "Introduction" , BookId = 1});
            modelBuilder.Entity<ChapterModel>().HasData(new ChapterModel { Id = 2, Title = "Deep Coding" , BookId = 1});
            // Chunks 
            modelBuilder.Entity<ChapterChunkModel>().HasData(new ChapterChunkModel { Id = 1, Title = "Deep Coding" , Body = "what is deep coding and why" ,ChapterId = 2 , CreatedAt = DateTime.Now , CurrentPage = 23 });
            modelBuilder.Entity<ChapterChunkModel>().HasData(new ChapterChunkModel { Id = 2, Title = "intro" , Body = "a small intro " ,ChapterId = 1 , CreatedAt = DateTime.Now , CurrentPage = 12 });
            
        }
    }
    
}