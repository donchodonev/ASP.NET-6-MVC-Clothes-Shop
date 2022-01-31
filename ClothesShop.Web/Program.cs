using ClothesShop.Data;
using ClothesShop.Web.Infrastructure;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetDefaultConnectionString();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options
    .UseLazyLoadingProxies()
    .UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper();

builder.Services.AddCustomServices();

var app = builder.Build();

app.UseExceptionsHandling(app.Environment);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints();

await app.PrepareDatabaseAsync();

app.Run();
