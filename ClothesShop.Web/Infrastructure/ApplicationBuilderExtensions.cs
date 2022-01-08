using ClothesShop.Data;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Web.Infrastructure
{
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


        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ShopDbContext>();

                db.Database.Migrate();

                return app;
            }
        }
    }
}
