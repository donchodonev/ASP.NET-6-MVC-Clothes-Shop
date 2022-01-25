namespace ClothesShop.Services
{
    using AutoMapper;

    using ClothesShop.Services.Models;

    public class CartService : ICartService
    {
        private readonly IProductService productsService;
        private readonly IMapper mapper;

        public CartService(IProductService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        public async Task<(bool Result, string Message)> IsOrderValidAsync(List<ProductCartServiceModel> products)
        {
            (bool Result, string Message) checksResult = (true, String.Empty);

            foreach (var product in products)
            {
                var currentProduct = await productsService.GetByIdAsync<ProductCheckServiceModel>(product.ProductId);

                if (currentProduct == null)
                {
                    return (false, "A product with the following ID does not exist");
                }
            }

            return checksResult;
        }
    }
}
