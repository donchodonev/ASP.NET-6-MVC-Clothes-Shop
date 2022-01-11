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

        DbSet<AgeGroup> AgeGroups { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<ClubCard> ClubCards { get; set; }

        DbSet<Discount> Discounts { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<Rating> Ratings { get; set; }

        DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasOne(client => client.Card)
                .WithOne(card => card.Client)
                .HasForeignKey<ClubCard>(client => client.ClientId);

            builder.Entity<Client>()
                .HasOne(client => client.ShoppingCart)
                .WithOne(shoppingCart => shoppingCart.Client)
                .HasForeignKey<ShoppingCart>(client => client.ClientId);

                        builder.Entity<Client>()
                .HasOne(client => client.ShippingAddress)
                .WithOne(shippingAddress => shippingAddress.Client)
                .HasForeignKey<ShippingAddress>(client => client.ClientId);

            base.OnModelCreating(builder);
        }
    }
}