namespace ClothesShop.Services
{
    using ClothesShop.Services.Models;

    public interface ICartService
    {
        public Task<IOrderValidationResult> IsOrderValidAsync(List<ProductCartServiceModel> products);
    }
}
