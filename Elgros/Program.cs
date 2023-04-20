using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using Microsoft.AspNetCore.Identity;

namespace Elgros
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);
            IConfiguration config = build.Build();

            // Initialize an instance of an IDatabase for manager injections
            config["elgrosdb"] = config.GetConnectionString("DefaultConnection");
            var db = DatabaseFactory.CreateDatabase(config, "elgrosdb", ElgrosLib.Adapters.DatabaseTypes.MySql);

            // Manager dependency
            builder.Services.AddScoped<ICategoryManager, CategoryManager>(manager => new CategoryManager(db));
            builder.Services.AddScoped<IProductManager, ProductManager>(manager => new ProductManager(db));
            builder.Services.AddScoped<ISubCategoryManager, SubCategoryManager>(manager => new SubCategoryManager(db));
            builder.Services.AddScoped<IUserManager, UserManager>(manager => new UserManager(db));
            builder.Services.AddScoped<IUserInformationManager, UserInformationManager>(manager => new UserInformationManager(db));

            LogFactory.Initialize(Environment.CurrentDirectory + "\\TestLogs.txt");
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.Run();
        }
    }
}