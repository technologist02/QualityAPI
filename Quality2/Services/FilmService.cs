using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
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
                config.CreateMap<Film, Database.FilmDto>();
                config.CreateMap<Database.FilmDto, Film>();
                config.CreateMap<FilmCreateView, Database.FilmDto>();
            }).CreateMapper();
        }
        public async Task AddFilmAsync(FilmCreateView film)
        {
            using var db = new Database.DataContext();
            var dbModel = Mapper.Map<Database.FilmDto>(film);
            await db.Films.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public Task DeleteFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            using var db = new Database.DataContext();
            var dbModel = await db.Films.Where(x => x.FilmId == id).FirstOrDefaultAsync();
            return Mapper.Map<Film>(dbModel);
        }

        public async Task<List<Film>> GetFilmsAsync()
        {
            using var db = new Database.DataContext();
            var dbModel = await db.Films.OrderBy(x=>x.Mark).ThenBy(x=>x.Thickness).ToListAsync();
            return Mapper.Map<List<Film>>(dbModel);
        }

        public async Task ChangeFilmAsync(Film newfilm)
        {
            using var db = new Database.DataContext();
            var film = await db.Films.Where(x => x.FilmId == newfilm.FilmId).FirstOrDefaultAsync();
            if (film != null)
            {
                film.Mark = newfilm.Mark;
                film.Thickness = newfilm.Thickness;
                film.Color = newfilm.Color;
                film.Density = newfilm.Density;
                await db.SaveChangesAsync();
            }
        }
    }
}
