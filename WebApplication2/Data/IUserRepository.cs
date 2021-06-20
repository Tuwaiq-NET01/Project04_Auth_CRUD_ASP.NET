using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public interface IUserRepository
    {
        StudentModel Create(StudentModel student);
        StudentModel GetByEmail(string email);
        StudentModel GetById(int id);
        List<CourseModel> getCourses();
        List<CourseStudentModel> getMyLearning(int id);
    }
}