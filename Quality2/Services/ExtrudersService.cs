using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using Quality2.Database;
using Quality2.Entities;
using Quality2.Exceptions;
using Quality2.IRepository;
using Quality2.ViewModels;

namespace Quality2.Services
{
    public class ExtrudersService : IExtrudersService
    {
        private static readonly IMapper Mapper;

        static ExtrudersService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Extruder, ExtruderDto>();
                config.CreateMap<ExtruderDto, Extruder>();
                config.CreateMap<ExtruderCreateView, ExtruderDto>();
            }).CreateMapper();
        }

        public async Task AddExtruderAsync(ExtruderCreateView extruder)
        {
            using var db = new DataContext();
            var check = await db.Extruders.SingleOrDefaultAsync(x => x.Name == extruder.Name);
            if (check != null)
            {
                throw new BadRequestException("Такой рабочий центр уже существует");
            }
            var dbModel = Mapper.Map<ExtruderDto>(extruder);
            await db.Extruders.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<Extruder> GetExtruderAsync(int id)
        {
            using var db = new DataContext();
            var dbModel = await db.Extruders.Where(x => x.ExtruderId == id).FirstOrDefaultAsync();
            return Mapper.Map<Extruder>(dbModel);
        }

        public async Task<List<Extruder>> GetExtrudersAsync()
        {
            using var db = new DataContext();
            var dbModel = await db.Extruders.ToListAsync();
            return Mapper.Map<List<Extruder>>(dbModel);
        }

        public async Task UpdateExtruderAsync(Extruder newExtruder)
        {
            using var db = new DataContext();
            var extruder = await db.Extruders.SingleOrDefaultAsync(x => x.ExtruderId == newExtruder.ExtruderId);
            if (extruder == null)
            {
                throw new NotFoundException("Такой рабочий центр не существует");
            }
            var dbModel = Mapper.Map<ExtruderDto>(newExtruder);
            db.Entry(extruder).CurrentValues.SetValues(dbModel);
            await db.SaveChangesAsync();
        }
    }
}
