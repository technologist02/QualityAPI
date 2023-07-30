using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IFilmService
    {
        public Task<List<Film>> GetFilmsAsync();

        public Task<Film> GetFilmAsync(int id);

        public Task AddFilmAsync(Film film);

        public Task DeleteFilmAsync(int id);
    }
}
