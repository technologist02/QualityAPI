using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quality2.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Quality2.AutorizationService;
using Quality2.Entities;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (user is null)
            {
                return BadRequest("Заполните все поля");
            }
            using var db = new DataContext();
            var check = await db.Users.AnyAsync(x => x.Name == user.Name || x.Email == user.Email);
            if (check)
            {
                return BadRequest("Пользователь с такими данными уже существует");
            }
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetUserTokenAsync(UserLogin user)
        {
            using var db = new DataContext();
            var login = !user.Name.Contains('@') ? await db.Users.FirstOrDefaultAsync(x => x.Name == user.Name && x.Password == user.Password) :
                await db.Users.FirstOrDefaultAsync(x => x.Email == user.Name && x.Password == user.Password);
            if (login == null)
            {
                return BadRequest("Неверный логин или пароль");
            }
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, login.Name) };
            var jwt = new JwtSecurityToken(
                    issuer: AuthorizationOptions.ISSUER,
                    audience: AuthorizationOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthorizationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Created("Success", encodedJwt);

        }
        [HttpGet]
        public async Task<IActionResult> GetUser() {
            var user = HttpContext.User.Identity;
            if (user is not null && user.IsAuthenticated)
            {
                return Ok(user.Name);
            }
            else return Unauthorized();
        }
    }
}

