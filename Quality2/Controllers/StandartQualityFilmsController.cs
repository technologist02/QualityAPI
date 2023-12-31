﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.QueryModels;
using Quality2.Services;
using Quality2.ViewModels;

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
        public async Task<IActionResult> GetStandartQualityFilmsAsync([FromQuery] StandartFilmsQuery query)
        {
            var standarts = await standartQualityFilmService.GetStandartQualityFilmsAsync(query);
            if (standarts == null)
            {
                return NotFound();
            }
            return Ok(standarts);
        }

        [HttpPost, Authorize]
        //[ProducesResponseType(typeof(StandartQualityFilm), 201)]
        public async Task<IActionResult> AddStandartQualityFilmAsync([FromBody] StandartQualityFilmCreateView standartQualityFilm)
        {
            await standartQualityFilmService.AddStandartQualityFilmAsync(standartQualityFilm);
            return Created("Success", standartQualityFilm);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOrderQualityAsync(StandartQualityFilm standartQualityFilm)
        {
            await standartQualityFilmService.UpdateStandartQualityFilmAsync(standartQualityFilm);
            return Accepted("Updated", standartQualityFilm);
        }
    }
}
