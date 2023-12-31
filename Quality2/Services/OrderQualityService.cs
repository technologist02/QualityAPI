﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using Quality2.Database;
using Quality2.IRepository;
using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using Quality2.ExcelServices;
using Quality2.ViewModels;
using Quality2.QueryModels;

namespace Quality2.Services
{
    public class OrderQualityService : IOrderQuailtyService
    {
        private static readonly IMapper Mapper;

        static OrderQualityService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderQualityView, OrderQualityDto>();
                config.CreateMap<OrderQuality, OrderQualityDto>();
                config.CreateMap<OrderQualityDto, OrderQuality>();
                config.CreateMap<FilmDto, Film>();
                config.CreateMap<Film, FilmDto>();
                config.CreateMap<StandartQualityFilmDto, StandartQualityFilm>();
                config.CreateMap<StandartQualityFilm, StandartQualityFilmDto>();
                config.CreateMap<StandartQualityTitle, StandartQualityTitleDto>();
                config.CreateMap<StandartQualityTitleDto, StandartQualityTitle>();
            }).CreateMapper();
        }
        public async Task AddOrderQualityAsync(OrderQualityView order)
        {
            using var db = new DataContext();
            var dbModel = Mapper.Map<OrderQualityDto>(order);
            dbModel.CreationDate = DateTime.Now.ToUniversalTime();
            await db.OrdersQuality.AddAsync(dbModel);
            await db.SaveChangesAsync();
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
            var order = await db.OrdersQuality.SingleOrDefaultAsync(x => x.OrderQualityId == changedOrder.OrderQualityId);
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
            var orderDb = await db.OrdersQuality
                .SingleOrDefaultAsync(x => x.OrderQualityId == id);
            if (orderDb == null)
            {
                return (Array.Empty<byte>(), 0);
            }
            else
            {
                var filmDb = await db.Films
                    .SingleOrDefaultAsync(x => x.FilmId == orderDb.FilmId);
                var standartTitleDb = await db.StandartQualityTitles
                    .SingleOrDefaultAsync(x => x.StandartQualityTitleId == orderDb.StandartQualityTitleId);
                var standartFilmDb = await db.StandartQualityFilms
                    .SingleOrDefaultAsync(x=>x.FilmId == orderDb.FilmId && x.StandartQualityTitleId == orderDb.StandartQualityTitleId);
                var order = Mapper.Map<OrderQuality>(orderDb);
                var film = Mapper.Map<Film>(filmDb);
                var standartTitle = Mapper.Map<StandartQualityTitle>(standartTitleDb);
                var standartFilm = standartFilmDb != null ? Mapper.Map<StandartQualityFilm>(standartFilmDb) : null;
                var package = Report.GetReport(order, standartFilm, film, standartTitle);
                //var excelData = package.GetAsByteArray();
                //var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //var fileName = id.ToString() + ".xlsx";
                return (package, order.OrderNumber);
            }
        }

        public async Task<OrderQuality> GetOrderQualityByIdAsync(int id)
        {
            using var db = new DataContext();
            var dbModel = await db.OrdersQuality.SingleOrDefaultAsync(x=>x.OrderQualityId == id);
            return Mapper.Map<OrderQuality>(dbModel);
        }

        /// <summary>
        /// Список заказов соответствующих фильтру
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderQuality>> GetFilteredOrdersAsync(OrdersQuery query)
        {
               
            using var db = new DataContext();
            var resultQuery = db.OrdersQuality.AsQueryable();
            if (!string.IsNullOrEmpty(query.Customer))
                resultQuery = resultQuery.Where(x => x.Customer.ToLower().Contains(query.Customer.ToLower()));
            if (!string.IsNullOrEmpty(query.OrderNumber))
                resultQuery = resultQuery.Where(x => x.OrderNumber.ToString().Contains(query.OrderNumber));
            if (!string.IsNullOrEmpty(query.FilmMark))
                resultQuery = resultQuery.Where(x => x.Film.Mark.ToLower().Contains(query.FilmMark.ToLower()));
            if (!string.IsNullOrEmpty(query.FilmThickness))
                resultQuery = resultQuery.Where(x => x.Film.Thickness.ToString().Contains(query.FilmThickness));
            if (!string.IsNullOrEmpty(query.FilmColor))
                resultQuery = resultQuery.Where(x => x.Film.Color.ToLower().ToLower().Contains(query.FilmColor.ToLower()));
            if (!string.IsNullOrEmpty(query.Extruder))
                resultQuery = resultQuery.Where(x => x.Extruder.Name.ToLower().Contains(query.Extruder.ToLower()));
            if (!string.IsNullOrEmpty(query.Width))
                resultQuery = resultQuery.Where(x => x.Width.ToString().Contains(query.Width));

            var result = await resultQuery.ToListAsync();
            return Mapper.Map<List<OrderQuality>>(result);
        }
    }
}
