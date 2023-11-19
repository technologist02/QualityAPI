﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.Exceptions;
using Quality2.IRepository;
using Quality2.ViewModels;

namespace Quality2.Services
{
    public class FilmService : IFilmService
    {
        private static readonly IMapper Mapper;
        
        static FilmService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Film, FilmDto>();
                config.CreateMap<FilmDto, Film>();
                config.CreateMap<FilmCreateView, FilmDto>();
            }).CreateMapper();
        }
        public async Task AddFilmAsync(FilmCreateView film)
        {
            using var db = new DataContext();
            var check = db.Films.SingleOrDefaultAsync(x => x.Mark == film.Mark && x.Thickness == film.Thickness && x.Color == film.Color);
            if (check != null)
            {
                throw new BadRequestException("Такая пленка уже существует");
            }
            var dbModel = Mapper.Map<FilmDto>(film);
            await db.Films.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public Task DeleteFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            using var db = new DataContext();
            var dbModel = await db.Films.Where(x => x.FilmId == id).FirstOrDefaultAsync();
            return Mapper.Map<Film>(dbModel);
        }

        public async Task<List<Film>> GetFilmsAsync()
        {
            using var db = new DataContext();
            var dbModel = await db.Films.OrderBy(x=>x.Mark).ThenBy(x=>x.Thickness).ToListAsync();
            return Mapper.Map<List<Film>>(dbModel);
        }

        public async Task ChangeFilmAsync(Film newfilm)
        {
            using var db = new DataContext();
            var film = await db.Films.Where(x => x.FilmId == newfilm.FilmId).FirstOrDefaultAsync();
            if (film != null)
            {
                film.Mark = newfilm.Mark;
                film.Thickness = newfilm.Thickness;
                film.Color = newfilm.Color;
                film.Density = newfilm.Density;
                await db.SaveChangesAsync();
            }
            else throw new NotFoundException("Такая пленка не существует");
        }
    }
}
