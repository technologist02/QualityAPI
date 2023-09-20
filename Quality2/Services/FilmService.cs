using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class FilmService : IFilmService
    {
        private static readonly IMapper Mapper;
        
        static FilmService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Film, Database.Film>();
                config.CreateMap<Database.Film, Film>();
            }).CreateMapper();
        }
        public async Task AddFilmAsync(Film film)
        {
            using var db = new Database.DataContext();
            var dbModel = Mapper.Map<Database.Film>(film);
            await db.Film.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public Task DeleteFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            using var db = new Database.DataContext();
            var dbModel = await db.Film.Where(x => x.ID == id).FirstOrDefaultAsync();
            return Mapper.Map<Film>(dbModel);
        }

        public async Task<List<Film>> GetFilmsAsync()
        {
            using var db = new Database.DataContext();
            var dbModel = await db.Film.OrderBy(x=>x.Mark).ThenBy(x=>x.Thickness).ToListAsync();
            return Mapper.Map<List<Film>>(dbModel);
        }

        public async Task<IResult> ChangeFilmAsync(Film newfilm)
        {
            using var db = new Database.DataContext();
            var film = await db.Film.Where(x => x.ID == newfilm.ID).FirstOrDefaultAsync();
            if (film == null)
            {
                return Results.NotFound();
            }
            else
            {
                film.Mark = newfilm.Mark;
                film.Thickness = newfilm.Thickness;
                film.Color = newfilm.Color;
                await db.SaveChangesAsync();
                return Results.Json(film);
            }
            
            
        }
    }
}
