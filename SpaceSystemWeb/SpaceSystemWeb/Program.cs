using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpaceSystemWeb.Data;
using SpaceSystemWebData;
using SpaceSystemWebRepositories;
using SpaceSystemWebServices;

namespace SpaceSystemWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            var sswdContext = builder.Configuration.GetConnectionString("SpaceSystem") ?? throw new InvalidOperationException("Connection string 'SpaceSystem' not found.");
            builder.Services.AddDbContext<SpaceSystemWebDbContext>(options =>
                options.UseSqlServer(sswdContext));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPlanetsService, PlanetsService>();
            builder.Services.AddScoped<IPlanetsRepository, PlanetsRepository>();
            //builder.Services.AddScoped<IContactsService, ContactsService>();
            //builder.Services.AddScoped<IContactsRepository, ContactsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}