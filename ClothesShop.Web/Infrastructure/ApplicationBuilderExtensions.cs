﻿namespace ClothesShop.Web.Infrastructure
{
    using ClothesShop.Data;
    using ClothesShop.Data.Entities;
    using ClothesShop.Data.Enums;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using static ClothesShop.Data.DataConstants.Client;

    public static class ApplicationBuilderExtensions
    {
        public static void UseEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
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

            if (db.AgeGroups.Any())
            {
                return;
            }

            db.AgeGroups.AddRange(new[]
            {
                new AgeGroup()
                {
                    Name = AgeGroupName.Babies,
                },
                 new AgeGroup()
                {
                    Name = AgeGroupName.Children,
                },
                  new AgeGroup()
                {
                    Name = AgeGroupName.Teenager,
                },
                 new AgeGroup()
                {
                    Name = AgeGroupName.Adult,
                },
            });

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
    }
}
