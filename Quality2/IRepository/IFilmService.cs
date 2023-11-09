using Quality2.Entities;
using Quality2.ViewModels;

namespace Quality2.IRepository
{
    public interface IFilmService
    {
        public Task<List<Film>> GetFilmsAsync();

        public Task<Film> GetFilmAsync(int id);

        public Task AddFilmAsync(FilmCreateView film);

        public Task DeleteFilmAsync(int id);
        public Task ChangeFilmAsync(Film film);
    }
}
