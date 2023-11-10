using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
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
                config.CreateMap<StandartQualityTitle, StandartQualityTitleDto>();
                config.CreateMap<StandartQualityTitleDto, StandartQualityTitle>();
            }).CreateMapper();
        }
        public async Task AddStandartQualityNameAsync(StandartQualityTitle standart)
        {
            using var db = new DataContext();
            var dbModel = Mapper.Map<StandartQualityTitleDto>(standart);
            await db.StandartQualityTitles.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<StandartQualityTitle> GetStandartQualityNameAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StandartQualityTitle>> GetStandartQualityNamesAsync()
        {
            using var db = new DataContext();
            var dbModel = await db.StandartQualityTitles.ToListAsync();
            return Mapper.Map<List<StandartQualityTitle>>(dbModel);
        }
    }
}
