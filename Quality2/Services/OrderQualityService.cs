using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using Quality2.Database;
using Quality2.IRepository;
using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using Quality2.ExcelServices;

namespace Quality2.Services
{
    public class OrderQualityService : IOrderQuailtyService
    {
        private static readonly IMapper Mapper;

        static OrderQualityService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Entities.OrderQuality, Database.OrderQuality>();
                config.CreateMap<Database.OrderQuality, Entities.OrderQuality>();
                config.CreateMap<Database.Film, Entities.Film>();
                config.CreateMap<Entities.Film, Database.Film>();
                config.CreateMap<Entities.StandartQualityFilm, Database.StandartQualityFilm>();
                config.CreateMap<Database.StandartQualityFilm, Entities.StandartQualityFilm>();
            }).CreateMapper();
        }
        public async Task AddOrderQualityAsync(Entities.OrderQuality order)
        {
            using var db = new DataContext();
            var dbModel = Mapper.Map<Database.OrderQuality>(order);
            await db.OrderQuality.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<Entities.OrderQuality> GetOrderQualityAsync(Entities.OrderQuality order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entities.OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber)
        {
            using var db = new DataContext();
            var orders = await db.OrderQuality.Where(x=>x.OrderNumber == orderNumber).ToListAsync();
            return Mapper.Map<List<Entities.OrderQuality>>(orders);
        }

        public async Task<List<Entities.OrderQuality>> GetOrdersQualityAsync()
        {
            using var db = new DataContext();
            var orders = await db.OrderQuality.ToListAsync();
            return Mapper.Map<List<Entities.OrderQuality>>(orders);
        }

        public async Task UpdateOrderQualityAsync(Entities.OrderQuality changedOrder)
        {
            using var db = new DataContext();
            var order = await db.OrderQuality.FirstOrDefaultAsync(x => x.ID == changedOrder.ID);
            if (order != null)
            {
                var dbModel = Mapper.Map<Database.OrderQuality>(changedOrder);
                db.Entry(order).CurrentValues.SetValues(dbModel);
                await db.SaveChangesAsync();
            }
        }

        public async Task<(byte[], int)> GetPassportQualityAsync(int id)
        {
            using var db = new DataContext();
            var order = await db.OrderQuality.FirstOrDefaultAsync(x => x.ID == id);
            if (order == null)
            {
                return (Array.Empty<byte>(), 0);
            }
            else
            {
                var standartQualityFilm = await db.StandartQualityFilms.FirstOrDefaultAsync(x=>x.FilmID == order.FilmID && x.StandartQualityNameID == order.StandartQualityNameID);
                var film = await db.Film.FirstOrDefaultAsync(x => x.ID == order.FilmID);
                var eOrder = Mapper.Map<Entities.OrderQuality>(order);
                var eFilm = Mapper.Map<Entities.Film>(film);
                var eStandartFilm =Mapper.Map<Entities.StandartQualityFilm>(standartQualityFilm);
                var package = Report.GetReport(eOrder, eStandartFilm, eFilm);
                //var excelData = package.GetAsByteArray();
                //var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //var fileName = id.ToString() + ".xlsx";
                return (package, order.OrderNumber);
            }
        }

        public async Task<Entities.OrderQuality> GetOrderQualityByIdAsync(int id)
        {
            using var db = new DataContext();
            var dbModel = await db.OrderQuality.FirstOrDefaultAsync(x=>x.ID == id);
            return Mapper.Map<Entities.OrderQuality>(dbModel);
        }
    }
}
