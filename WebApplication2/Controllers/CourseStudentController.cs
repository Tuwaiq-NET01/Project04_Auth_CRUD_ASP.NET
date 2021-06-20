using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Helpers;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api")]
    public class CourseStudentController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public CourseStudentController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }
        
        [HttpGet("mylearning/{id:int}")]
        public IActionResult Index(int id)
        {
            return Ok(_repository.getMyLearning(id));
        }
    }
}