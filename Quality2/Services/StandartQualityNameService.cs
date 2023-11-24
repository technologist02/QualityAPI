﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class StandartQualityTitleService : IStandartQualityTitleService
    {
        private static readonly IMapper Mapper;

        static StandartQualityTitleService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<StandartQualityTitle, StandartQualityTitleDto>();
                config.CreateMap<StandartQualityTitleDto, StandartQualityTitle>();
            }).CreateMapper();
        }
        public async Task AddStandartQualityTitleAsync(StandartQualityTitle standart)
        {
            using var db = new DataContext();
            var dbModel = Mapper.Map<StandartQualityTitleDto>(standart);
            await db.StandartQualityTitles.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<StandartQualityTitle> GetStandartQualityTitleAsync(int id)
        {
            using var db = new DataContext();
            var dbModel = await db.StandartQualityTitles.SingleOrDefaultAsync(x => x.StandartQualityTitleId == id);
            return Mapper.Map<StandartQualityTitle>(dbModel);
        }

        public async Task<List<StandartQualityTitle>> GetStandartQualityTitlesAsync()
        {
            using var db = new DataContext();
            var dbModel = await db.StandartQualityTitles.ToListAsync();
            return Mapper.Map<List<StandartQualityTitle>>(dbModel);
        }
    }
}
