using Quality2.Entities;
using Quality2.QueryModels;
using Quality2.ViewModels;

namespace Quality2.IRepository
{
    public interface IFilmService
    {
        public Task<List<Film>> GetFilmsAsync();

        public Task<Film> GetFilmAsync(int id);

        public Task<Film> AddFilmAsync(FilmCreateView film);

        public Task DeleteFilmAsync(int id);
        public Task<Film> ChangeFilmAsync(Film film);
        public Task<IEnumerable<Film>> GetFilteredFilmsAsync(FilmsQuery query);
    }
}
