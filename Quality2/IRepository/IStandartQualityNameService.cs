using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IStandartQualityTitleService
    {
        public Task<List<StandartQualityTitle>> GetStandartQualityTitlesAsync();

        public Task<StandartQualityTitle> GetStandartQualityTitleAsync(int id);

        public Task<StandartQualityTitle> AddStandartQualityTitleAsync(StandartQualityTitle standart);

        public Task<StandartQualityTitle> UpdateStandartQualityTitleAsync(StandartQualityTitle standart);
    }
}
