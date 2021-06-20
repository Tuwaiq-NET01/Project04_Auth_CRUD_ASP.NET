using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Helpers;

namespace WebApplication2.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public StudentController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }
        
        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}