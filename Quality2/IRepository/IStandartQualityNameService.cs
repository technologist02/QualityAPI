using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IStandartQualityNameService
    {
        public Task<List<StandartQualityTitle>> GetStandartQualityNamesAsync();

        public Task<StandartQualityTitle> GetStandartQualityNameAsync(int id);

        public Task AddStandartQualityNameAsync(StandartQualityTitle standart);
    }
}
