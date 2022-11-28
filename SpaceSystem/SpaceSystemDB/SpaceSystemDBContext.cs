using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaceSystemModels.PeopleModels;
using SpaceSystemModels.SpaceBodyModels;

namespace SpaceSystemDB
{
    public class SpaceSystemDBContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public SpaceSystemDBContext()
        {

        }
        public SpaceSystemDBContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var config = builder.Build();
                var cnstr = config["ConnectionStrings:SpaceSystemDB"];
                var options = new DbContextOptionsBuilder<SpaceSystemDBContext>().UseSqlServer(cnstr);
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>(x =>
            {
                x.HasData(
                    new Planet() { Id = 1, BoughtId = 0, Name = "Mercury", OrbitInDays = 88, Moons = 0, GravitationalPull = 3.7M },
                    new Planet() { Id = 2, BoughtId = 0, Name = "Venus", OrbitInDays = 225, Moons = 0, GravitationalPull = 8.9M },
                    new Planet() { Id = 3, BoughtId = 0, Name = "Earth", OrbitInDays = 365, Moons = 1, GravitationalPull = 9.8M },
                    new Planet() { Id = 4, BoughtId = 0, Name = "Mars", OrbitInDays = 687, Moons = 2, GravitationalPull = 3.7M },
                    new Planet() { Id = 5, BoughtId = 0, Name = "Jupiter", OrbitInDays = 4333, Moons = 57, GravitationalPull = 23.1M },
                    new Planet() { Id = 6, BoughtId = 0, Name = "Saturn", OrbitInDays = 10759, Moons = 63, GravitationalPull = 9.0M },
                    new Planet() { Id = 7, BoughtId = 0, Name = "Uranus", OrbitInDays = 30687, Moons = 27, GravitationalPull = 8.7M },
                    new Planet() { Id = 8, BoughtId = 0, Name = "Neptune", OrbitInDays = 60190, Moons = 14, GravitationalPull = 11.0M }
                );
            });
            modelBuilder.Entity<Star>(x =>
            {
                x.HasData(
                    new Star() { Id = 1, BoughtId = 0, Name = "Sun", Brightness = -26.74M, Temperature = 1 }
                    );
            });

            modelBuilder.Entity<Employee>(x =>
            {
                x.HasData(
                    new Employee() { Id = 1, FirstName = "David", LastName = "Diaz", Email = "admin@rentastar.com", Username = "admin", Password = "Password" }
                );
            });
        }
    }
}