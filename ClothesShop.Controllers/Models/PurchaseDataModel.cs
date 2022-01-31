namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Services.Contracts;

    public class PurchaseDataModel
    {
        public IEnumerable<PurchaseDetailsViewModel> Purchases { get; set; }

        public PurchaseShippingDetailsViewModel ShippingDetails { get; set; }

        public async Task PopulateModelAsync(IOrderService orders, IProductService products, string orderId)
        {
            await GetPurchasedProductsInfoAsync(orders, orderId);
            await GetPurchasesImageURLsAsync(products);
            await GetShippingDetailsAsync(orders, orderId);

        }

        private async Task GetPurchasedProductsInfoAsync(IOrderService orders, string orderId)
        {
            Purchases = await orders.GetPurchasesAsync<PurchaseDetailsViewModel>(orderId);
        }

        private async Task GetPurchasesImageURLsAsync(IProductService products)
        {
            foreach (var product in Purchases)
            {
                product.ImageURL = await products.GetImageUrlAsync(product.ProductId);
            }
        }

        private async Task GetShippingDetailsAsync(IOrderService orders, string orderId)
        {
            ShippingDetails = await orders.GetShippingDetailsAsync<PurchaseShippingDetailsViewModel>(orderId);
        }
    }
}
