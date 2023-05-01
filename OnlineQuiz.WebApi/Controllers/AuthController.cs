using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineQuiz.Domain;
using OnlineQuiz.WebApi.DTO;
using OnlineQuiz.WebApi.Helpers;
using OnlineQuiz.WebApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineQuiz.WebApi.Controllers
{
    public class AuthController : BaseController
    { 
        private readonly IUserService _db;
        private readonly JwtService _token;

        public AuthController(IConfiguration configuration, IUserService db, JwtService token)
        {
            _db = db;
            //_configuration = configuration;
            _token = token;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            };
            if(userDto == null)
            {
                return BadRequest("No data for register user");
            }

            var regUser = await _db.FindUser(userDto.Email);
            
            if(regUser == null)
            {
                await _db.CreateUser(user);
            }
            else
            {
                return BadRequest("User already registered");
            }
           
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            //var user = new User();
            var user = await _db.FindUser(userDto.Email);
            
            if(user == null)
            {
                return BadRequest("User not found");
            }
            if(!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password");
            }

            string token = _token.CreateToken(user);

            var tok = new TokenDto
            {
                UserId = user.Id, 
                UserEmail = user.Email,
                AccessToken = token,
                Message = "Welcome"
            };
            return Ok(tok);
        }

    }
}
