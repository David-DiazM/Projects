using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaceSystemWebModels;

namespace SpaceSystemWebData
{
    public class SpaceSystemWebDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }

        public SpaceSystemWebDbContext()
        {
            //purposefully empty for scaffolding
        }

        public SpaceSystemWebDbContext(DbContextOptions options)
        {
            //purposefully empty will set options appropriately
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("SpaceSystem");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>(x =>
            {
                x.HasData(
                    new Planet() { Id = 1, BoughtId = 0, Name = "Mercury", OrbitInDays = 88, Moons = 0, GravitationalPull = 3.7 },
                    new Planet() { Id = 2, BoughtId = 0, Name = "Venus", OrbitInDays = 225, Moons = 0, GravitationalPull = 8.9 },
                    new Planet() { Id = 3, BoughtId = 0, Name = "Earth", OrbitInDays = 365, Moons = 1, GravitationalPull = 9.8 },
                    new Planet() { Id = 4, BoughtId = 0, Name = "Mars", OrbitInDays = 687, Moons = 2, GravitationalPull = 3.7 },
                    new Planet() { Id = 5, BoughtId = 0, Name = "Jupiter", OrbitInDays = 4333, Moons = 57, GravitationalPull = 23.1 },
                    new Planet() { Id = 6, BoughtId = 0, Name = "Saturn", OrbitInDays = 10759, Moons = 63, GravitationalPull = 9.0 },
                    new Planet() { Id = 7, BoughtId = 0, Name = "Uranus", OrbitInDays = 30687, Moons = 27, GravitationalPull = 8.7 },
                    new Planet() { Id = 8, BoughtId = 0, Name = "Neptune", OrbitInDays = 60190, Moons = 14, GravitationalPull = 11.0 }
                );
            });
            modelBuilder.Entity<Star>(x =>
            {
                x.HasData(
                    new Star() { Id = 1, BoughtId = 0, Name = "Sun", Brightness = -26.74, Temperature = 5778 }
                    );
            });
        }
    }
}