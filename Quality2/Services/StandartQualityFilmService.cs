using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.Exceptions;
using Quality2.IRepository;
using Quality2.QueryModels;
using Quality2.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Quality2.Services
{
    public class StandartQualityFilmService : IStandartQualityFilmService
    {
        private static readonly IMapper Mapper;

        static StandartQualityFilmService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<StandartQualityFilm, StandartQualityFilmDto>();
                config.CreateMap<StandartQualityFilmDto, StandartQualityFilm>();
                config.CreateMap<StandartQualityFilmCreateView, StandartQualityFilmDto>();
                config.CreateMap<FilmDto, Film>();
                config.CreateMap<Film, FilmDto>();
            }).CreateMapper();
        }

        public async Task AddStandartQualityFilmAsync(StandartQualityFilmCreateView standartQualityFilm)
        {
            using var db = new DataContext();
            var standart = await db.StandartQualityFilms.SingleOrDefaultAsync(x => x.StandartQualityTitleId == standartQualityFilm.StandartQualityTitleId && x.FilmId == standartQualityFilm.FilmId);
            if (standart != null)
            {
                throw new BadRequestException($"Эталон качества на пленку {standart.Film.Mark} {standart.Film.Thickness} {standart.Film.Color} по стандарту {standart.StandartQualityTitle.Title} уже существует");
            }
            var dbModel = Mapper.Map<StandartQualityFilmDto>(standartQualityFilm);
            await db.StandartQualityFilms.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<StandartQualityFilm> GetStandartQualityFilmByFilmIdAsync(int id)
        {
            using var db = new DataContext();
            var standart = await db.StandartQualityFilms
                .SingleOrDefaultAsync(x => x.StandartQualityFilmId == id);
            return Mapper.Map<StandartQualityFilm>(standart);
        }

        public async Task<List<StandartQualityFilm>> GetStandartQualityFilmsAsync(StandartFilmsQuery query)
        {
            using var db = new DataContext();
            var resultQuery = db.StandartQualityFilms.AsQueryable();
            if (!string.IsNullOrEmpty(query.Mark))
                resultQuery = resultQuery.Where(x => x.Film.Mark.ToLower().Contains(query.Mark.ToLower()));
            if (!string.IsNullOrEmpty(query.Thickness))
                resultQuery = resultQuery.Where(x => x.Film.Thickness.ToString().Contains(query.Thickness));
            if (!string.IsNullOrEmpty(query.Color))
                resultQuery = resultQuery.Where(x => x.Film.Color.ToLower().Contains(query.Color));
            if(!string.IsNullOrEmpty(query.StandartTitle))
                resultQuery = resultQuery.Where(x => x.StandartQualityTitle.Title.ToLower().Contains(query.StandartTitle));

            var result = await resultQuery
                .OrderBy(x => x.Film.Mark)
                .ToListAsync();
            return Mapper.Map<List<StandartQualityFilm>>(result);
        }

        public async Task UpdateStandartQualityFilmAsync(StandartQualityFilm changedStandartQualityFilm)
        {
            using var db = new DataContext();
            var standart = await db.StandartQualityFilms
                .SingleOrDefaultAsync(x => x.StandartQualityFilmId == changedStandartQualityFilm.StandartQualityFilmId);
            if (standart != null)
            {
                var dbModel = Mapper.Map<StandartQualityFilmDto>(changedStandartQualityFilm);
                db.Entry(standart).CurrentValues.SetValues(dbModel);
                await db.SaveChangesAsync();
            }
        }
    }
}
