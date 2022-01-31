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

        public DbSet<ClubCardTier> ClubCardTiers { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<GenderGroup> GenderGroups { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<ShippingDetails> ShippingDetails { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchaseOrder> PurchasesOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasOne(client => client.Card)
                .WithOne(card => card.Client)
                .HasForeignKey<ClubCard>(client => client.ClientId);

            builder.Entity<Client>()
                .HasOne(client => client.ShippingDetails)
                .WithOne(shippingAddress => shippingAddress.Client)
                .HasForeignKey<ShippingDetails>(client => client.ClientId);

            builder.Entity<Order>()
                .HasOne(sa => sa.ShippingDetails)
                .WithMany(sa => sa.Orders)
                .HasForeignKey(order => order.ShippingDetailsId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PurchaseOrder>()
                .HasKey(po => new { po.PurchaseId, po.OrderId });

            builder.Entity<PurchaseOrder>()
                .HasOne<Order>()
                .WithMany(p => p.PurchasesOrders)
                .HasForeignKey(productOrder => productOrder.OrderId);

            builder.Entity<PurchaseOrder>()
                .HasOne<Purchase>()
                .WithMany(p => p.PurchasesOrders)
                .HasForeignKey(purchaseOrder => purchaseOrder.PurchaseId);

            base.OnModelCreating(builder);
        }
    }
}