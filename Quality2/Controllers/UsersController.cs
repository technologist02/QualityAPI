using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.ViewModels;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync() 
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRolesAsync()
        {
            var roles = await userService.GetRolesAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRolesAsync(UpdateUserRolesView user)
        {
            await userService.UpdateUserRolesAsync(user);
            return Ok(user);
        }

    }
}
