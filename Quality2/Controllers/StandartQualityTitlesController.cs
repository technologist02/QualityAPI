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
    public class StandartQualityTitlesController : ControllerBase
    {
        private readonly IStandartQualityNameService standartQualityNameService;

        public StandartQualityTitlesController(IStandartQualityNameService standartQualityNameService)
        {
            this.standartQualityNameService = standartQualityNameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStandartQualityNamesAsync()
        {
            var result = await standartQualityNameService.GetStandartQualityNamesAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost, Authorize]
        [ProducesResponseType(typeof(StandartQualityTitle), 201)]
        public async Task<IActionResult> AddFilmAsync([FromBody] StandartQualityTitle standartQualityName)
        {
            await standartQualityNameService.AddStandartQualityNameAsync(standartQualityName);
            return Created("Success", standartQualityName);
        }
    }
}
