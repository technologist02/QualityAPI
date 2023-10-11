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
    public class StandartQualityFilmsController : ControllerBase
    {
        private readonly IStandartQualityFilmService standartQualityFilmService;

        public StandartQualityFilmsController(IStandartQualityFilmService standartQualityFilmService)
        {
            this.standartQualityFilmService = standartQualityFilmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStandartQualityFilmsAsync()
        {
            var standarts = await standartQualityFilmService.GetStandartQualityFilmsAsync();
            if (standarts == null)
            {
                return NotFound();
            }
            return Ok(standarts);
        }

        [HttpPost, Authorize]
        [ProducesResponseType(typeof(StandartQualityName), 201)]
        public async Task<IActionResult> AddStandartQualityFilmAsync([FromBody] StandartQualityFilm standartQualityFilm)
        {
            await standartQualityFilmService.AddStandartQualityFilmAsync(standartQualityFilm);
            return Created("Success", standartQualityFilm);
        }
    }
}
