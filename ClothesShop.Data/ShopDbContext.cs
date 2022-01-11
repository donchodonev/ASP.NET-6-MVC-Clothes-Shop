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

        public DbSet<AgeGroup> AgeGroups { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClubCard> ClubCards { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

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