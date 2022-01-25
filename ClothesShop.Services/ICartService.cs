namespace ClothesShop.Services
{
    using ClothesShop.Services.Models;

    public interface ICartService
    {
        public Task<(bool Result, string Message)> IsOrderValidAsync(List<ProductCartServiceModel> products);
    }
}
