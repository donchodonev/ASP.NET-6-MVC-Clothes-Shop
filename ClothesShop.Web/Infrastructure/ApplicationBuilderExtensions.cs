namespace ClothesShop.Web.Infrastructure
{
    using ClothesShop.Controllers.Models.Product;
    using ClothesShop.Data;
    using ClothesShop.Data.Entities;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using System.Text.Json;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ClientConstants;

    public static class ApplicationBuilderExtensions
    {
        public static void UseEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "AdminArea_Home_Index",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "AdminArea_Product_Add",
                    pattern: "{area:exists}/{controller=Products}/{action=Add}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "All Products",
                    pattern: "{controller=Products}/{action=All}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Product Details",
                    pattern: "{controller=Products}/{action=Details}/{productId}");

                endpoints.MapControllerRoute(
                    name: "Cart View",
                    pattern: "{controller=Cart}/{action=View}");

                endpoints.MapRazorPages();
            });
        }

        public static void UseCookieCart(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<HttpContext>();

            app.Use(async (context, next) =>
            {
                if (!context.Request.Cookies.ContainsKey("ClothesShopShoppingCart"))
                {
                    var emptyJsonObject = JsonSerializer.Serialize(new Dictionary<string, ProductCartCookieModel>());

                    context.Response.Cookies.Append("ClothesShopShoppingCart", emptyJsonObject);
                }

                await next();
            });
        }

        public static void UseExceptionsHandling(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
        }

        public static async Task PrepareDatabaseAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                await Migrate(services);
                await SeedAgeGroups(services);
                await SeedAdministrator(services);
                await SeedProductCategories(services);
                await SeedGenderGroups(services);
            }
        }

        private static async Task Migrate(IServiceProvider services)
        {
            var data = services.GetRequiredService<ShopDbContext>();

            await data.Database.MigrateAsync();
        }

        private static async Task SeedAgeGroups(IServiceProvider services)
        {
            var db = services.GetService<ShopDbContext>();

            if (await db.AgeGroups.AnyAsync())
            {
                return;
            }

            await db.AgeGroups.AddRangeAsync(new[]
            {
                new AgeGroup()
                {
                    Name = "Babies",
                },
                 new AgeGroup()
                {
                    Name = "Children",
                },
                  new AgeGroup()
                {
                    Name = "Teenagers",
                },
                 new AgeGroup()
                {
                    Name = "Adults",
                },
            });

            await db.SaveChangesAsync();
        }

        private static async Task SeedProductCategories(IServiceProvider services)
        {
            var db = services.GetService<ShopDbContext>();

            if (db.ProductCategories.Any())
            {
                return;
            }

            db.ProductCategories.Add(
                new ProductCategory()
                {
                    Name = "T-Shirt",
                }
            );

            await db.SaveChangesAsync();
        }

        private static async Task SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<Client>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (await roleManager.RoleExistsAsync(AdminRoleName))
            {
                return;
            }

            var role = new IdentityRole { Name = AdminRoleName };

            await roleManager.CreateAsync(role);

            const string adminEmail = "admin@clothes.com";
            const string adminPassword = "123456";

            var user = new Client
            {
                Email = adminEmail,
                UserName = adminEmail,
            };

            var result = await userManager.CreateAsync(user, adminPassword);

            await userManager.AddToRoleAsync(user, role.Name);
        }

        private static async Task SeedGenderGroups(IServiceProvider services)
        {
            var db = services.GetService<ShopDbContext>();

            if (db.GenderGroups.Any())
            {
                return;
            }

            await db.GenderGroups.AddRangeAsync(new[]
            {
                new GenderGroup()
                {
                    Name = "Male"
                },
                new GenderGroup()
                {
                    Name = "Female"
                }
            });

            await db.SaveChangesAsync();
        }
    }
}
