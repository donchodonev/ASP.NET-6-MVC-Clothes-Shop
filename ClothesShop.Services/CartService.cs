namespace ClothesShop.Services
{
    using AutoMapper;

    using ClothesShop.Services.Models;

    public class CartService : ICartService
    {
        private readonly IProductService products;
        private readonly IMapper mapper;

        public CartService(IProductService products, IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
        }

        public async Task<bool> IsOrderValid(List<ProductCartServiceModel> products)
        {
            return true;
        }
    }
}
