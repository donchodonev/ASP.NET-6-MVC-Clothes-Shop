using ClothesShop.Controllers;
using ClothesShop.Data;
using ClothesShop.Data.Entities;
using ClothesShop.Services;

using Microsoft.AspNetCore.Identity;


namespace ClothesShop.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDefaultIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<Client>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ShopDbContext>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(IProductService).Assembly,
                typeof(HomeController).Assembly);
        }

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IGenderService, GenderService>();
        }
    }
}
