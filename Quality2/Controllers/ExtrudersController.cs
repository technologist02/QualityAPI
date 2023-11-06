using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.Requests;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrudersController : ControllerBase
    {
        private readonly IExtrudersService _extrudersService;
        private readonly IMediator _mediator;

        public ExtrudersController(IExtrudersService extrudersService, IMediator mediator)
        {
            _extrudersService = extrudersService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetExtrudersAsync()
        {
            var result = await _extrudersService.GetExtrudersAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("test-mediator")]
        public async Task<IActionResult> GetExtrudersByMediatorAsync()
        {
            var result = await _mediator.Send(new GetExtrudersRequest());
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExtruderAsync(int id)
        {
            var result = await _extrudersService.GetExtruderAsync(id);
            return result == null ? NotFound() : Ok(result);

        }

        [HttpPost, Authorize]
        [ProducesResponseType(typeof(Extruder), 201)]
        public async Task<IActionResult> AddExtruderAsync([FromBody] Extruder extruder)
        {
            await _extrudersService.AddExtruderAsync(extruder);
            return Created("Success", extruder);
        }
    }
}
