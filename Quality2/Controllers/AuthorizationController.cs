using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.ViewModels;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService userService;
        public AuthorizationController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync(UserRegisterView user)
        {
            await userService.RegisterUserAsync(user);
            return Created("Success", user.Login);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUserAsync(UserLogin login)
        {
            var token = await userService.LoginUserAsync(login);
            return string.IsNullOrEmpty(token) ? Unauthorized() : Ok(token);

        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetUserData()
        {
            var user = HttpContext.User.Identity;
            if (user is not null && user.IsAuthenticated)
            {
                return Ok(HttpContext.User.Claims.ToList());
            }
            else return Unauthorized();
        }
    }
}
