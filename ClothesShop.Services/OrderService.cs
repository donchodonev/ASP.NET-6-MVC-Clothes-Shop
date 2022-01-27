namespace ClothesShop.Services
{
    using ClothesShop.Data;
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models.Product;

    using Microsoft.EntityFrameworkCore;

    using System.Text;

    public class OrderService : IOrderService
    {
        private readonly ShopDbContext db;

        public OrderService(ShopDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateOrderAsync(
            ProductAndSizeServiceModel[] productAndSizeIds,
            string country,
            string city,
            string street,
            string postalCode,
            string clientId = null)
        {
            var order = new Order();

            order.ShippingAddress = new ShippingAddress();

            order.ShippingAddressId = order.ShippingAddress.Id;
            order.ShippingAddress.Country = country;
            order.ShippingAddress.City = city;
            order.ShippingAddress.Street = street;
            order.ShippingAddress.PostalCode = postalCode;

            var query = CreateUpdateQuery(productAndSizeIds);

            db.Orders.Add(order);

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    await db.Database.ExecuteSqlRawAsync(query);
                    await db.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Something went wrong with your order");
                }
            }

            return order.Id;
        }

        private string CreateUpdateQuery(ProductAndSizeServiceModel[] productAndSizeIds)
        {
            StringBuilder query = new StringBuilder();

            foreach (var product in productAndSizeIds)
            {
                query.AppendLine("Update [Sizes]");
                query.AppendLine("SET [Count] = [Count] - 1");
                query.AppendLine($"WHERE [Id] = {product.SizeId} AND [ProductId] = {product.ProductId}");
                query.AppendLine();
            }

            return query.ToString().TrimEnd();
        }
    }
}
