﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using Quality2.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService filmService;

        public FilmsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmsAsync()
        { 
            var result = await filmService.GetFilmsAsync();
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmAsync(int id)
        {
            var result = await filmService.GetFilmAsync(id);
            return result == null ? NotFound() : Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(typeof(Film), 201)]
        public async Task<IActionResult> AddFilmAsync([FromBody] Film film)
        {
            await filmService.AddFilmAsync(film);
            return Created("Success", film);
        }
        [HttpPatch]
        public async Task<IActionResult> ChangeFilmAsync(Film film)
        {
            await filmService.ChangeFilmAsync(film);
            return Ok(film);
        }
    }
}