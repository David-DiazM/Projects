using EntityFrameworkModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EntityFrameworkDB
{
    public class EntityFrameworkDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public EntityFrameworkDBContext()
        {

        }
        public EntityFrameworkDBContext(DbContextOptions options)
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
                var cnstr = config["ConnectionStrings:EntityFrameworkDB"];
                var options = new DbContextOptionsBuilder<EntityFrameworkDBContext>().UseSqlServer(cnstr);
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
    }
}