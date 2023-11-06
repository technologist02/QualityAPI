using Microsoft.EntityFrameworkCore;

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
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
            {
                return;
            }
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true)
               .Build();
            var connectionString = config.GetConnectionString("Pg");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
