namespace ClothesShop.Services.Contracts
{
    using ClothesShop.Services.Models.Product;

    public interface IOrderService
    {
        public Task<string> CreateOrderAsync(
    ProductAndSizeServiceModel[] productAndSizeIds,
    string country,
    string city,
    string street,
    string postalCode,
    string clientId = null);
    }
}
