using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.QueryModels;
using Quality2.Services;
using Quality2.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService filmService;
        private readonly ILogger<FilmsController> logger;

        public FilmsController(IFilmService filmService, ILogger<FilmsController> logger)
        {
            this.filmService = filmService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmsAsync()
        { 
            var result = await filmService.GetFilmsAsync();
            if (result == null)
            {
                return NotFound();
            }
            //logger.LogInformation("Запрос всех пленок");
            //logger.LogWarning("Запрос всех пленок");
            //logger.LogDebug("Запрос всех пленок");
            //logger.LogCritical("Запрос всех пленок");
            //logger.LogTrace("Запрос всех пленок");
            //logger.LogError("Запрос всех пленок");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmAsync(int id)
        {
            var result = await filmService.GetFilmAsync(id);
            return result == null ? NotFound() : Ok(result);

        }

        [HttpPost, Authorize]
        [ProducesResponseType(typeof(FilmCreateView), 201)]
        public async Task<IActionResult> AddFilmAsync([FromBody] FilmCreateView film)
        {
            await filmService.AddFilmAsync(film);
            logger.LogInformation("попытка добавить пленку {film}", film);
            return Created("Success", film);
        }
        [HttpPatch, Authorize]
        public async Task<IActionResult> ChangeFilmAsync(Film film)
        {
            await filmService.ChangeFilmAsync(film);
            return Ok(film);
        }

        [HttpGet("search")]
        public async Task<IActionResult> FilterOrders([FromQuery] FilmsQuery query)
        {
            var result = await filmService.GetFilteredFilmsAsync(query);
            return Ok(result);
        }
    }
}
