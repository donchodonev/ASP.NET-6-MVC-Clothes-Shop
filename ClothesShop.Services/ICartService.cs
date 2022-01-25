namespace ClothesShop.Services
{
    using ClothesShop.Services.Models;

    public interface ICartService
    {
        public Task<bool> IsOrderValid(List<ProductCartServiceModel> products);
    }
}
