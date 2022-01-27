namespace ClothesShop.Services
{
    using ClothesShop.Data;
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using System.Text;

    public class OrderService : IOrderService
    {
        private readonly ShopDbContext db;
        private readonly ICartService cart;

        public OrderService(ShopDbContext db, ICartService cart)
        {
            this.db = db;
            this.cart = cart;
        }

        public async Task<string> CreateOrderAsync(
        ProductAndSizeServiceModel[] productAndSizeIds,
        HttpContext context, OrderRecipientDataModel recipientData,
        string clientId = null)
        {
            var order = new Order();

            order.ShippingDetails = new ShippingDetails();

            order.ShippingDetailsId = order.ShippingDetails.Id;

            order.ShippingDetails.Country = recipientData.Country;

            order.ShippingDetails.RecipientFirstName = recipientData.FirstName;

            order.ShippingDetails.RecipientLastName = recipientData.LastName;

            order.ShippingDetails.Country = recipientData.Country;

            order.ShippingDetails.City = recipientData.City;

            order.ShippingDetails.Street = recipientData.Street;

            order.ShippingDetails.PostalCode = recipientData.PostalCode;

            var query = CreateUpdateQuery(productAndSizeIds);

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    await db.Database.ExecuteSqlRawAsync(query);

                    db.Orders.Add(order);

                    await db.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Something went wrong with your order");
                }
            }

            cart.Clear(context);

            return order.Id;
        }

        //Unparameterizer raw SQL queries are bad, except when they're not
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
