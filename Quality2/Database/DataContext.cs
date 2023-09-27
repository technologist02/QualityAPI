using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quality2.Database
{
    public class DataContext: DbContext
    {
        public DbSet<Film> Film { get; set; }
        public DbSet<StandartQualityFilm> QualityStandarts { get; set; }
        public DbSet<OrderQuality> OrderQuality { get; set; }
        public DbSet<Extruder> Extruder { get; set; }
        public DbSet<StandartQualityName> StandartQualityNames { get; set; }
        public DbSet<StandartQualityFilm> StandartQualityFilms { get; set; }

        public DataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Quality2;Username=postgres;Password=return;");
        }
    }
}
