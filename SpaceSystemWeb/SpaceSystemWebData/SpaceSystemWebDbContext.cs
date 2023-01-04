using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SpaceSystemWebData
{
    public class SpaceSystemWebDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public SpaceSystemWebDbContext()
        {
            //purposefully empty: Necessary for scaffolding
        }

        public SpaceSystemWebDbContext(DbContextOptions options)
            : base(options)
        {
            //purposefully empty, sets options appropriately
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
    }
}