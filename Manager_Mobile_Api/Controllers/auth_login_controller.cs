using Manager_mobile_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager_Mobile_Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _context.UserKey
                .FirstOrDefault(x =>
                    x.UserName == dto.Username &&
                    x.PasswordHash == dto.Password);

            if (user == null)
                return Unauthorized("Sai tài khoản hoặc mật khẩu");

            return Ok(new
            {
                user.UserID,
                user.UserName,
                message = "Login success"
            });
        }
    }
}
public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
