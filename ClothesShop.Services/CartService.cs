namespace ClothesShop.Services
{
    using ClothesShop.Services.Models;

    public class CartService : ICartService
    {
        private readonly IProductService productsService;

        public CartService(IProductService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IOrderValidationResult> IsOrderValidAsync(List<ProductCartServiceModel> products)
        {
            foreach (var product in products)
            {
                var dbProduct = await productsService.GetByIdAsync<ProductCheckServiceModel>(product.ProductId);

                var dbProductName = dbProduct.Name;
                var dbProductBrand = dbProduct.Manufacturer;
                var productIdentity = $"{dbProductName} by {dbProductBrand}";
                var aTag = $@"<a href='https://localhost:7206/Products/Details?productId={product.ProductId}'>{productIdentity}</a>";
                var dueToThatSentence = "Due to that - the product has been removed from your cart.If you still with to purchase it - re-add it to your cart which will automatically correct the product parameters.";

                if (dbProduct == null)
                {
                    return new OrderValidationResult(false, product.ProductId, "A product with the following ID does not exist.");
                }
                else if (dbProduct.Price != product.Price)
                {
                    return new OrderValidationResult(false, product.ProductId, $@"{aTag} has a different price. Price from the cart shows ${product.Price} while the real price from our database shows ${dbProduct.Price.ToString("F2")}. {dueToThatSentence}");
                }
                else if (dbProduct.ImageURL != product.ImageURL)
                {
                    return new OrderValidationResult(false, product.ProductId, $"{aTag} has a different ImageURL. The image url from the client is ${product.ImageURL} while the real image URL is ${dbProduct.ImageURL}. {dueToThatSentence}");
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
