using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class StandartQualityFilmService : IStandartQualityFilmService
    {
        private static readonly IMapper Mapper;

        static StandartQualityFilmService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Entities.StandartQualityFilm, Database.StandartQualityFilm>();
                config.CreateMap<Database.StandartQualityFilm, Entities.StandartQualityFilm>();
                config.CreateMap<Database.Film, Entities.Film>();
                config.CreateMap<Entities.Film, Database.Film>();
            }).CreateMapper();
        }

        public async Task AddStandartQualityFilmAsync(Entities.StandartQualityFilm standartQualityFilm)
        {
            using var db = new DataContext();
            var dbModel = Mapper.Map<Database.StandartQualityFilm>(standartQualityFilm);
            await db.StandartQualityFilms.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<Entities.StandartQualityFilm> GetStandartQualityFilmByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entities.StandartQualityFilm>> GetStandartQualityFilmsAsync()
        {
            using var db = new DataContext();
            var dbModel = await db.StandartQualityFilms.ToListAsync();
            return Mapper.Map<List<Entities.StandartQualityFilm>>(dbModel);
        }

        public async Task<IResult> UpdateStandartQualityFilmAsync(Entities.StandartQualityFilm changedStandartQualityFilm)
        {
            using var db = new DataContext();
            var standart = await db.StandartQualityFilms.FirstOrDefaultAsync(x => x.ID == changedStandartQualityFilm.ID);
            if (standart == null)
            {
                return Results.NotFound();
            }
            else
            {
                standart = Mapper.Map<Database.StandartQualityFilm>(changedStandartQualityFilm);
                db.Attach(standart);
                //order.OrderNumber = changedOrder.OrderNumber;
                //order.RollNumber = changedOrder.RollNumber;
                //order.BrigadeNumber = changedOrder.BrigadeNumber;
                //order.Width = changedOrder.Width;
                //order.Customer = changedOrder.Customer;
                await db.SaveChangesAsync();
                return Results.Json(standart);
            }
        }
    }
}
