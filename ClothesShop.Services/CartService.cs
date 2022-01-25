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

        public async Task<IOrderValidationResult> IsOrderValidAsync(List<ProductCartServiceModel> products)
        {
            foreach (var product in products)
            {
                var dbProduct = await productsService.GetByIdAsync<ProductCheckServiceModel>(product.ProductId);

                var dbProductName = dbProduct.Name;
                var dbProductBrand = dbProduct.Manufacturer;
                var productIdentity = $"{dbProductName} by {dbProductBrand}";

                if (dbProduct == null)
                {
                    return new OrderValidationResult(false, product.ProductId, "A product with the following ID does not exist.");
                }
                else if (dbProduct.Price != product.Price)
                {
                    return new OrderValidationResult(false, product.ProductId, $"{productIdentity} has a different price. Price from client is ${product.Price} while the real price is ${dbProduct.Price}.");
                }
                else if (dbProduct.ImageURL != product.ImageURL)
                {
                    return new OrderValidationResult(false, product.ProductId, $"{productIdentity} has a different ImageURL. The image url from the client is ${product.ImageURL} while the real image URL is ${dbProduct.ImageURL}.");
                }
                else if (!dbProduct.Sizes.Any(x => x.Id == product.SizeId))
                {
                    return new OrderValidationResult(false, product.ProductId, $"{productIdentity} doesn't have any remaining stock of the chosen size.");
                }
                else if (dbProduct.Sizes.First(size => size.Id == product.SizeId).Count < product.Count)
                {
                    var productOfParticularSizeCount = dbProduct.Sizes.First(size => size.Id == product.SizeId).Count;

                    return new OrderValidationResult(false, product.ProductId, $"{productIdentity} has only {productOfParticularSizeCount} pieces remaining in stock");
                }

                var count = product.Count;
                var price = dbProduct.Price;
                var total = price * count;

                if (total != product.Total)
                {
                    return new OrderValidationResult(false, product.ProductId, $"{count} pieces of {productIdentity} amount to {total} as {count} * {price} = {total}.");
                }
            }

            return new OrderValidationResult(true, 0, string.Empty);
        }
    }
}
