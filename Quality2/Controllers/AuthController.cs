using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quality2.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Quality2.AutoOptions;
using Quality2.Entities;
using Microsoft.AspNetCore.Authorization;

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
            else
            {
                Console.WriteLine(check);
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                return Created("Success", user);
            }

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
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)), // время действия
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Created("Success", encodedJwt);

        }
        [HttpGet, Authorize]
        public async Task<IActionResult> GetUser() {
            var user =  HttpContext.User.Identity;
            if (user is not null && user.IsAuthenticated)
            {
                return Ok(user.Name);
            }
            else return Unauthorized();
        }
    }
}

