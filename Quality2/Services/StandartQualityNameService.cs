using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddStandartQualityNameAsync(StandartQualityName standart)
        {
            using var db = new Database.DataContext();
            var dbModel = Mapper.Map<Database.StandartQualityName>(standart);
            await db.StandartQualityNames.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<StandartQualityName> GetStandartQualityNameAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StandartQualityName>> GetStandartQualityNamesAsync()
        {
            using var db = new Database.DataContext();
            var dbModel = await db.StandartQualityNames.ToListAsync();
            return Mapper.Map<List<StandartQualityName>>(dbModel);
        }
    }
}
