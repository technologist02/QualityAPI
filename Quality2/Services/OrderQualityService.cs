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
                config.CreateMap<OrderQuality, OrderQualityDto>();
                config.CreateMap<OrderQualityDto, OrderQuality>();
                config.CreateMap<FilmDto, Film>();
                config.CreateMap<Film, FilmDto>();
                config.CreateMap<StandartQualityFilmDto, StandartQualityFilm>();
                config.CreateMap<StandartQualityFilm, StandartQualityFilmDto>();
            }).CreateMapper();
        }
        public async Task AddOrderQualityAsync(OrderQuality order)
        {
            using var db = new DataContext();
            var dbModel = Mapper.Map<OrderQualityDto>(order);
            await db.OrdersQuality.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<OrderQuality> GetOrderQualityAsync(OrderQuality order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber)
        {
            using var db = new DataContext();
            var orders = await db.OrdersQuality.Where(x=>x.OrderNumber == orderNumber).ToListAsync();
            return Mapper.Map<List<OrderQuality>>(orders);
        }

        public async Task<List<OrderQuality>> GetOrdersQualityAsync()
        {
            using var db = new DataContext();
            var orders = await db.OrdersQuality.ToListAsync();
            return Mapper.Map<List<OrderQuality>>(orders);
        }

        public async Task UpdateOrderQualityAsync(OrderQuality changedOrder)
        {
            using var db = new DataContext();
            var order = await db.OrdersQuality.FirstOrDefaultAsync(x => x.OrderQualityId == changedOrder.OrderQualityId);
            if (order != null)
            {
                var dbModel = Mapper.Map<OrderQualityDto>(changedOrder);
                db.Entry(order).CurrentValues.SetValues(dbModel);
                await db.SaveChangesAsync();
            }
        }

        public async Task<(byte[], int)> GetPassportQualityAsync(int id)
        {
            using var db = new DataContext();
            var order = await db.OrdersQuality.FirstOrDefaultAsync(x => x.OrderQualityId == id);
            if (order == null)
            {
                return (Array.Empty<byte>(), 0);
            }
            else
            {
                var standartQualityFilm = await db.StandartQualityFilms
                    .FirstOrDefaultAsync(x=>x.FilmId == order.Film.FilmId && x.StandartQualityTitle.StandartQualityTitleId == order.StandartQualityTitle.StandartQualityTitleId);
                var film = await db.Films.FirstOrDefaultAsync(x => x.FilmId == order.Film.FilmId);
                var eOrder = Mapper.Map<OrderQuality>(order);
                var eFilm = Mapper.Map<Film>(film);
                var eStandartFilm = standartQualityFilm != null ? Mapper.Map<StandartQualityFilm>(standartQualityFilm) : null;
                var package = Report.GetReport(eOrder, eStandartFilm, eFilm);
                //var excelData = package.GetAsByteArray();
                //var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //var fileName = id.ToString() + ".xlsx";
                return (package, order.OrderNumber);
            }
        }

        public async Task<OrderQuality> GetOrderQualityByIdAsync(int id)
        {
            using var db = new DataContext();
            var dbModel = await db.OrdersQuality.FirstOrDefaultAsync(x=>x.OrderQualityId == id);
            return Mapper.Map<OrderQuality>(dbModel);
        }
    }
}
