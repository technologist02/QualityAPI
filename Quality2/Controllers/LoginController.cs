using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quality2.AutorizationService;
using Quality2.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetUserTokenAsync(string[] data)
        {
            if (data.Length != 2)
            {
                return BadRequest("Че каво");
            }
            using var db = new DataContext();
            var user =  await db.Users.FirstOrDefaultAsync(x => x.Name == data[0] && x.Password == data[1]);
            if (user == null)
            {
                return BadRequest("Неверный логин или пароль");
            }
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name) };
            var jwt = new JwtSecurityToken(
                    issuer: AuthorizationOptions.ISSUER,
                    audience: AuthorizationOptions.AUDIENCE,
                    claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(AuthorizationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Created("Success", encodedJwt);
            
        } 
    }
}
