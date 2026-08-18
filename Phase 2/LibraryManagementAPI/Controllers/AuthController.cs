using LibraryManagementAPI.DTOs;
using LibraryManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    /* Api controller validates the identity that this file is a controller
    that handles HTTP requests*/
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /* This first class is mainly responsible for attaching 
        the service from the interface to the controller using DI
        
        And the remaninng each class is mapping HTTP request with the Business logic
        and registering the data either coming from the user or sending back to the user*/
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]            // POST /api/auth/register
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            /* here [FromBody] tells ASP.NET to Take the data from the HTTP request body.
            and RegisterDto tells .NET that The data coming from the client should be
            represented as a RegisterDto object.
            
            where dto works for converting the data from JSON into C# object
            ex...{  "username": "mangesh",
                    "email": "mangesh@gmail.com",
                    "password": "123456"}
                into
                                
                dto.Username = "mangesh"
                dto.Email = "mangesh@gmail.com"
                dto.Password = "123456"
            */
            var result = _authService.Register(dto);
            /* AuthService, here is the registration data. Please handle the registration. */
            return Ok(result);
        }

        [HttpPost("login")]               // POST /api/auth/login — returns JWT token
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var result = _authService.Login(dto);
            return Ok(result);
        }
    }
}
