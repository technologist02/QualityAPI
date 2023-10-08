using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        public async Task<IActionResult> Register([FromBody] User user)
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
            return Created("Регистарция прошла успешно", user);
        }
    }
}
