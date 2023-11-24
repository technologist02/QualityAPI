using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.Exceptions;
using Quality2.IRepository;
using Quality2.ViewModels;

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
            var standart = await db.StandartQualityFilms.SingleOrDefaultAsync(x => x.StandartQualityFilmId == id);
            return Mapper.Map<StandartQualityFilm>(standart);
        }

        public async Task<List<StandartQualityFilm>> GetStandartQualityFilmsAsync()
        {
            using var db = new DataContext();
            var dbModel = await db.StandartQualityFilms
                .OrderBy(x => x.Film.Mark)
                .ToListAsync();
            return Mapper.Map<List<StandartQualityFilm>>(dbModel);
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
