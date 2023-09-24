using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.Services;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandartQualityNamesController : ControllerBase
    {
        private readonly IStandartQualityNameService standartQualityNameService;

        public StandartQualityNamesController(IStandartQualityNameService standartQualityNameService)
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

        [HttpPost]
        [ProducesResponseType(typeof(StandartQualityName), 201)]
        public async Task<IActionResult> AddFilmAsync([FromBody] StandartQualityName standartQualityName)
        {
            await standartQualityNameService.AddStandartQualityNameAsync(standartQualityName);
            return Created("Success", standartQualityName);
        }
    }
}
