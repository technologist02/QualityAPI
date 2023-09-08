using AutoMapper;
using Quality2.Entities;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class StandartQualityNameService : IStandartQualityNameService
    {
        private static readonly IMapper Mapper;

        static StandartQualityNameService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<StandartQualityName, Database.StandartQualityName>();
                config.CreateMap<Database.StandartQualityName, StandartQualityName>();
            }).CreateMapper();
        }
        public Task AddStandartQualityFilmAsync(StandartQualityFilm standart)
        {
            throw new NotImplementedException();
        }

        public Task<StandartQualityFilm> GetStandartQualityFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StandartQualityFilm>> GetStandartQualityFilmsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
