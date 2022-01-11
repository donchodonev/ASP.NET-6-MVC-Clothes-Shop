using ClothesShop.Controllers;
using ClothesShop.Data;
using ClothesShop.Data.Entities;
using ClothesShop.Services.Shop;
using ClothesShop.Web.Infrastructure;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetDefaultConnectionString();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Client>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShopDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(
    typeof(IShopService).Assembly,
    typeof(HomeController).Assembly);

var app = builder.Build();


app.UseExceptionsHandling(app.Environment);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints();

app.SeedData();

app.Run();
