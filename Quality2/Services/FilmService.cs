using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class FilmService : IFilmService
    {
        private DataContext dbContext;
        public FilmService(DataContext dbContext) 
        {  
            this.dbContext = dbContext; 
        }
        public async Task AddFilmAsync(Film film)
        {
            await dbContext.Film.AddAsync(film);
            await dbContext.SaveChangesAsync();
        }

        public Task DeleteFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            var film = await dbContext.Film.Where(x => x.ID == id).FirstOrDefaultAsync();
            return film;
        }

        public async Task<List<Film>> GetFilmsAsync()
        {
            var films = await dbContext.Film.ToListAsync();
            return films;
        }
    }
}
