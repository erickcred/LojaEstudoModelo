using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Hosting;

namespace ECommerce;

public class Program
{
    public static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureSevices(builder);
        ConfiguracoesMVC(builder);

        var app = builder.Build();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            // app.MapControllers();
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller:Home}/{action=Index}/{id}"
            );
        });

        app.Run();

        void ConfigureSevices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ECommerceContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }

        void ConfiguracoesMVC(WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
        }

    }

}