namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Controllers.Models.Product;
    using ClothesShop.Services.Contracts;

    public class OrderDetailsViewModel
    {
        public ProductOrderDetailsViewModel[] Products { get; set; }

        public OrderShippingDetailsViewModel ShippingDetails { get; set; }

        public async Task GetProductsAsync(IOrderService orders, string productId)
        {
            Products = await orders.FindByIdAsync<ProductOrderDetailsViewModel[]>(productId);
            ShippingDetails = await orders.FindByIdAsync<OrderShippingDetailsViewModel>(productId);
        }
    }
}
