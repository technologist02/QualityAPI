using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IStandartQualityTitleService
    {
        public Task<List<StandartQualityTitle>> GetStandartQualityTitlesAsync();

        public Task<StandartQualityTitle> GetStandartQualityTitleAsync(int id);

        public Task AddStandartQualityTitleAsync(StandartQualityTitle standart);
    }
}
