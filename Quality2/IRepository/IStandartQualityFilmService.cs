﻿using Quality2.Entities;
using Quality2.QueryModels;
using Quality2.ViewModels;

namespace Quality2.IRepository
{
    public interface IStandartQualityFilmService
    {
        public Task<List<StandartQualityFilm>> GetStandartQualityFilmsAsync(StandartFilmsQuery standart);
        public Task<StandartQualityFilm> GetStandartQualityFilmByFilmIdAsync(int id);
        public Task AddStandartQualityFilmAsync(StandartQualityFilmCreateView standartQualityFilm);
        public Task UpdateStandartQualityFilmAsync(StandartQualityFilm standartQualityFilm);
    }
}
