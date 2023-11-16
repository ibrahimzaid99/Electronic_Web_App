using Electronic_Web_App.Models;
using Electronic_Web_App.Models.Authontication;
using Electronic_Web_App.Repository.CartRepository;
using Electronic_Web_App.Repository.CategoriesRepository;
using Electronic_Web_App.Repository.ProductsRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Electronic_Web_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MVC_Project_Context>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddIdentity<ApplicationIdentityUser, IdentityRole>(
                options => {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                }
                 ).AddEntityFrameworkStores<MVC_Project_Context>();
            builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}