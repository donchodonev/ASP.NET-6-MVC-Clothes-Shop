﻿namespace ClothesShop.Services
{
    using AutoMapper;

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
        private readonly IMapper mapper;

        public OrderService(ShopDbContext db, ICartService cart, IMapper mapper)
        {
            this.db = db;
            this.cart = cart;
            this.mapper = mapper;
        }

        public async Task<string> CreateOrderAsync(
        ProductAndSizeServiceModel[] productAndSizeIds,
        HttpContext context, OrderRecipientDataModel recipientData,
        string clientId = null)
        {
            var order = new Order()
            {
                ShippingDetails = mapper.Map<ShippingDetails>(recipientData),
                Status = Data.Enums.OrderStatus.Pending
            };

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

            order.ShippingDetailsId = order.ShippingDetails.Id;

            cart.Clear(context);

            return order.Id;
        }

        //Unparameterized raw SQL queries are bad, except when they're not
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