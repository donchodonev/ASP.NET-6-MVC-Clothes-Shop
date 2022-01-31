namespace ClothesShop.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

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

            var purchaseOrders = CreatePurchaseOrders(productAndSizeIds, order);

            var reduceBoughtProductSizeCount = CreateUpdateQuery(productAndSizeIds);

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    await db.Database.ExecuteSqlRawAsync(reduceBoughtProductSizeCount);

                    await db.Purchases.AddRangeAsync(purchaseOrders.Select(x => x.Purchase));

                    await db.SaveChangesAsync();

                    AddPurchaseIds(purchaseOrders);

                    await db.Orders.AddRangeAsync(purchaseOrders.Select(x => x.Order));

                    await db.OrdersPurchases.AddRangeAsync(purchaseOrders);

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

        /// <summary>
        /// Returns the requested projection if the order exists, null if it doesn't
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TModel> FindByIdAsync<TModel>(string id) where TModel : class
        {
            if (!await ExistsAsync(id))
            {
                return null;
            }

            return db
                .Orders
                .Where(x => x.Id == id)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .First();
        }

        public async Task<bool> ExistsAsync(string orderId, bool withDeleted = false)
        {
            return await db.Orders.AnyAsync(x => x.Id == orderId && x.IsDeleted == withDeleted);
        }

        //Unparameterized raw SQL queries are bad, except when they're not
        private string CreateUpdateQuery(ProductAndSizeServiceModel[] productAndSizeIds)
        {
            StringBuilder query = new StringBuilder();

            foreach (var product in productAndSizeIds)
            {
                query.AppendLine("Update [Sizes]");
                query.AppendLine($"SET [Count] = [Count] - {product.Count}");
                query.AppendLine($"WHERE [Id] = {product.SizeId} AND [ProductId] = {product.ProductId}");
                query.AppendLine();
            }

            return query.ToString().TrimEnd();
        }

        private Stack<OrderPurchase> CreatePurchaseOrders(ProductAndSizeServiceModel[] products, Order order)
        {
            var purchaseOrdersStack = new Stack<OrderPurchase>();

            foreach (var product in products)
            {
                var purchase = new Purchase()
                {
                    ProductId = product.ProductId,
                    Price = product.Price,
                    SizeId = product.SizeId,
                    Count = product.Count
                };

                purchaseOrdersStack.Push(new OrderPurchase()
                {
                    Purchase = purchase,
                    Order = order,
                    OrderId = order.Id,
                    PurchaseId = purchase.Id
                });
            }

            return purchaseOrdersStack;
        }

        public void AddPurchaseIds(Stack<OrderPurchase> purchaseOrders)
        {
            foreach (var po in purchaseOrders)
            {
                po.PurchaseId = po.Purchase.Id;
            }
        }
    }
}
