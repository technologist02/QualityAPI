using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class ExtrudersService : IExtrudersService
    {
        private static readonly IMapper Mapper;

        static ExtrudersService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Extruder, Database.Extruder>();
                config.CreateMap<Database.Extruder, Extruder>();
            }).CreateMapper();
        }

        public async Task AddExtruderAsync(Extruder extruder)
        {
            using var db = new Database.DataContext();
            var dbModel = Mapper.Map<Database.Extruder>(extruder);
            await db.Extruder.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<Extruder> GetExtruderAsync(int id)
        {
            using var db = new Database.DataContext();
            var dbModel = await db.Extruder.Where(x => x.ID == id).FirstOrDefaultAsync();
            return Mapper.Map<Extruder>(dbModel);
        }

        public async Task<List<Extruder>> GetExtrudersAsync()
        {
            using var db = new Database.DataContext();
            var dbModel = await db.Extruder.ToListAsync();
            return Mapper.Map<List<Extruder>>(dbModel);
        }
    }
}
