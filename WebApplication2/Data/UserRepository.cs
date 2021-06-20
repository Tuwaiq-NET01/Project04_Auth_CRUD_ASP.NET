using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public StudentModel Create(StudentModel student)
        {
            _context.Students.Add(student);
            student.Id = _context.SaveChanges();

            return student;
        }

        public StudentModel GetByEmail(string email)
        {
            return _context.Students.FirstOrDefault(student => student.Email == email);
        }

        public StudentModel GetById(int id)
        {
            return _context.Students.FirstOrDefault(student => student.Id == id);
        }

        public List<CourseModel> getCourses()
        {
            return _context.Courses.Include(course => course.Instructor).ToList();
        }

        public List<CourseStudentModel> getMyLearning(int id)
        {
            return _context.CoursesStudents
                .Include(c => c.CourseModel)
                .ThenInclude(course => course.Instructor)
                .Where(course => course.StudentModelId == id).ToList();
        }
    }
}