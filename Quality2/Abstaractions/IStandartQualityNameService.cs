using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IStandartQualityNameService
    {
        public Task<List<StandartQualityName>> GetStandartQualityNamesAsync();

        public Task<StandartQualityName> GetStandartQualityNameAsync(int id);

        public Task AddStandartQualityNameAsync(StandartQualityName standart);
    }
}
