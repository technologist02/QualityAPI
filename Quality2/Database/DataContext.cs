using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using System.Collections.Generic;

namespace Quality2.Database
{
    public class DataContext: DbContext
    {
        public DbSet<FilmDto> Films { get; set; }
        public DbSet<OrderQualityDto> OrdersQuality { get; set; }
        public DbSet<ExtruderDto> Extruders { get; set; }
        public DbSet<StandartQualityTitleDto> StandartQualityTitles { get; set; }
        public DbSet<StandartQualityFilmDto> StandartQualityFilms { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<RoleDto> Roles { get; set; }

        public DataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=QualityV3;Username=postgres;Password=return;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<StandartQualityFilmDto>()
        //        .HasOne(u => u.StandartQualityTitle);
        //}
    }
}
