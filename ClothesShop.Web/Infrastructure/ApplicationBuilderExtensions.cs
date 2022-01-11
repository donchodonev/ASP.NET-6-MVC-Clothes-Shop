namespace ClothesShop.Web.Infrastructure
{

    using ClothesShop.Data;
    using ClothesShop.Data.Entities;
    using ClothesShop.Data.Enums;

    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            return app;
        }

        public static IApplicationBuilder UseExceptionsHandling(
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

            return app;
        }


        public static async Task<IApplicationBuilder> PrepareDatabaseAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                await Migrate(services);
                await SeedAgeGroups(services);

                return app;
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
    }
}
