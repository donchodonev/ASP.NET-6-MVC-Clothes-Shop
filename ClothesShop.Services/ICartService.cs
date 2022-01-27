namespace ClothesShop.Services
{
    using ClothesShop.Services.Models;

    using Microsoft.AspNetCore.Http;

    public interface ICartService
    {
        public Task<IOrderValidationResult> IsOrderValidAsync(List<ProductCartServiceModel> products);

        public Dictionary<string, ProductCartCookieModel> Get(HttpContext context);

        public void Clear(HttpContext context);

        public void Add(HttpContext context, ProductCartCookieModel product);

        public bool IsProductInCart(HttpContext context, string productKey);

        public int UniqueProductsCount(HttpContext context);

        public ProductCountChangeServiceModel? IncreaseProductCountById(HttpContext context, string productKey);

        public ProductCountChangeServiceModel? DecreaseProductCountById(HttpContext context, string productKey);

    }
}
