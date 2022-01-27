namespace ClothesShop.Services.Contracts
{
    using ClothesShop.Services.Models;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Http;

    public interface ICartService
    {
        public Task<IOrderValidationResult> IsOrderValidAsync(HttpContext context, List<ProductCartServiceModel> products);

        public Dictionary<string, ProductCartCookieModel> Get(HttpContext context);

        public void Clear(HttpContext context);

        public void Add(HttpContext context, ProductCartCookieModel product);

        public bool IsProductInCart(HttpContext context, string productKey);

        public int UniqueProductsCount(HttpContext context);

        public ProductCountChangeServiceModel? IncreaseProductCountById(HttpContext context, string productKey);

        public ProductCountChangeServiceModel? DecreaseProductCountById(HttpContext context, string productKey);

        public void Remove(HttpContext context, int productId);
    }
}
