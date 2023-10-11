using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.Services;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrudersController : ControllerBase
    {
        private readonly IExtrudersService extrudersService;

        public ExtrudersController(IExtrudersService extrudersService)
        {
            this.extrudersService = extrudersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExtrudersAsync()
        {
            var result = await extrudersService.GetExtrudersAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExtruderAsync(int id)
        {
            var result = await extrudersService.GetExtruderAsync(id);
            return result == null ? NotFound() : Ok(result);

        }

        [HttpPost, Authorize]
        [ProducesResponseType(typeof(Extruder), 201)]
        public async Task<IActionResult> AddExtruderAsync([FromBody] Extruder extruder)
        {
            await extrudersService.AddExtruderAsync(extruder);
            return Created("Success", extruder);
        }
    }
}
