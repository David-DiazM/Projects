using EntityFrameworkDB;
using EntityFrameworkModels;
using Microsoft.Extensions.Configuration;

namespace EntityFramework
{
    public class Program
    {
        public static IConfigurationRoot _configuration;
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

            //-----------------------------------------------------------------------------------------------------------------------------------------//

            //accessing database
            using EntityFrameworkDBContext context = new EntityFrameworkDBContext();
            {
                //add product to database
                //Product chickenBaconRanchPizza = new Product();
                //chickenBaconRanchPizza.Name = "Chicken Bacon Ranch";
                //chickenBaconRanchPizza.Price = 12.99M;

                //context.Products.Add(chickenBaconRanchPizza);
                //context.SaveChanges();

                //updating product in product table
                var veggiePizza = context.Products
                                    .Where(p => p.Name == "Veggie Special Pizza")
                                    .FirstOrDefault();

                if (veggiePizza is Product)
                {
                    veggiePizza.Price = 10.99M;
                }
                context.SaveChanges();

                //delete entity from database
                //var cbrPizza = context.Products
                //                    .Where(p => p.Name == "Chicken Bacon Ranch")
                //                    .FirstOrDefault();

                //if (cbrPizza is Product)
                //{
                //    context.Products.Remove(cbrPizza);
                //}
                //context.SaveChanges();

                //iterating through product table and selecting products where it matches values
                var products = context.Products
                                .Where(p => p.Price > 10.00M)
                                .OrderBy(p => p.Name);

                foreach (var p in products)
                {
                    Console.WriteLine($"Id: {p.Id}");
                    Console.WriteLine($"Name: {p.Name}");
                    Console.WriteLine($"Price: {p.Price}");
                    Console.WriteLine(new string('-', 80));
                }
            }
        }
    }
}