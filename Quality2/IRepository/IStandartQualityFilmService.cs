using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IStandartQualityFilmService
    {
        public Task<List<StandartQualityFilm>> GetStandartQualityFilmsAsync();
        public Task<StandartQualityFilm> GetStandartQualityFilmByIdAsync(int id);
        //public Task<List<OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber);

        public Task AddStandartQualityFilmAsync(StandartQualityFilm standartQualityFilm);

        public Task<IResult> UpdateStandartQualityFilmAsync(StandartQualityFilm standartQualityFilm);
    }
}
