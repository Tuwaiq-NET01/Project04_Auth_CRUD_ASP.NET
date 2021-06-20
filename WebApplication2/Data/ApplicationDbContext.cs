using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<StudentModel> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>(entity => entity.HasIndex(e => e.Email).IsUnique());
        }

        public DbSet<InstructorModel> Instructors { get; set; }
        
        public DbSet<FeedModel> Feeds { get; set; }
        
        public DbSet<CourseModel> Courses { get; set; }

        public DbSet<CourseStudentModel> CoursesStudents { get; set; }
    }
}