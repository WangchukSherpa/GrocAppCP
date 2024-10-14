
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjWork.Data;
using ProjWork.Dto;
using ProjWork.Entities.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authintication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public AuthController(ProductDbContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(a => a.Email == user.Email))
            {
                return BadRequest("Email already exists");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Registration successful.");
        }


        [HttpPost("login")]
        public IActionResult Post([FromBody] LogInDto user)
        {
            if (user == null)
                return BadRequest();

            var dbUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (dbUser != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, dbUser.Email),  // We'll use this as the basket ID
            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Role, "User")
        };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7275",
                    audience: "https://localhost:7275",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}
