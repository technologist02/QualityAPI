using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IStandartQualityFilmService
    {
        public Task<List<StandartQualityFilm>> GetStandartQualityFilmsAsync();
        public Task<StandartQualityFilm> GetStandartQualityFilmByFilmIdAsync(int id);
        public Task AddStandartQualityFilmAsync(StandartQualityFilm standartQualityFilm);
        public Task UpdateStandartQualityFilmAsync(StandartQualityFilm standartQualityFilm);
    }
}
