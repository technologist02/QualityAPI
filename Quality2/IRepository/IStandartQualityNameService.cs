using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IStandartQualityNameService
    {
        public Task<List<StandartQualityFilm>> GetStandartQualityFilmsAsync();

        public Task<StandartQualityFilm> GetStandartQualityFilmAsync(int id);

        public Task AddStandartQualityFilmAsync(StandartQualityFilm standart);
    }
}
