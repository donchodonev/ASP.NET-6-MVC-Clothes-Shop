namespace ClothesShop.Data
{
    using ClothesShop.Data.Entities;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ShopDbContext : IdentityDbContext<Client>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }
    }
}