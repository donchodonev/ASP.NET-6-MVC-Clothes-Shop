namespace ClothesShop.Services
{
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Http;

    using System.Text.Json;

    using static ClothesShop.Data.Miscellaneous.DataConstants;

    public class CartService : ICartService
    {
        private readonly IProductService productsService;

        public CartService(IProductService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IOrderValidationResult> IsOrderValidAsync(HttpContext context, List<ProductCartServiceModel> products)
        {
            foreach (var product in products)
            {
                var dbProduct = await productsService.GetByIdAsync<ProductCheckServiceModel>(product.ProductId);

                if (dbProduct == null)
                {
                    Remove(context, product.ProductId);
                    return new OrderValidationResult(false, product.ProductId, "A product with a non-existing has been removed from your cart.");
                }

                var dbProductName = dbProduct.Name;

                var dbProductBrand = dbProduct.Manufacturer;

                var productIdentity = $"{dbProductName} by {dbProductBrand}";

                var aTag = $@"<a href='https://localhost:7206/Products/Details?productId={product.ProductId}'>{productIdentity}</a>";

                var dueToThatSentence = "Due to the found discrepancies, the product has been removed from your cart. If you still with to purchase it - re-add it to your cart which will automatically correct the product parameters.";

                if (dbProduct.Price != product.Price)
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
                    return new OrderValidationResult(false, product.ProductId, $"{count} pieces of {productIdentity} amount to {total} as {count} * {price} = {total}. {dueToThatSentence}");
                }
            }

            return new OrderValidationResult(true, 0, string.Empty);
        }

        public Dictionary<string, ProductCartCookieModel> Get(HttpContext context)
        {
            try
            {
                return JsonSerializer.Deserialize<Dictionary<string, ProductCartCookieModel>>(context.Request.Cookies[CartConstants.CookieKey]);
            }
            catch (Exception)
            {
                Clear(context);
                return new Dictionary<string, ProductCartCookieModel>();
            }
        }

        public void Clear(HttpContext context)
        {
            var emptyCart = new Dictionary<string, ProductCartCookieModel>();

            context.Response.Cookies.Delete(CartConstants.CookieKey);

            context.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(emptyCart), CartConstants.CookieOptions);
        }

        public void Add(HttpContext context, ProductCartCookieModel product)
        {
            var cart = Get(context);

            var productKey = $"{product.ProductId}:{product.SizeId}";

            if (cart.ContainsKey(productKey))
            {
                cart[productKey].Count += product.Count;
            }
            else
            {
                cart.Add(productKey, product);
            }

            context.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);
        }

        public void Remove(HttpContext context, int productId)
        {
            var cart = Get(context);

            var product = cart.Values.First(x => x.ProductId == productId);

            foreach (var key in cart.Keys)
            {
                if (cart[key] == product)
                {
                    cart.Remove(key);

                    break;
                }
            }

            context.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart),CartConstants.CookieOptions);
        }

        public int UniqueProductsCount(HttpContext context)
        {
            return Get(context).Values.Where(x => x.Count > 0).Count();
        }

        public bool IsProductInCart(HttpContext context, string productKey)
        {
            return Get(context).Keys.Any(x => x == productKey);
        }

        public ProductCountChangeServiceModel? IncreaseProductCountById(HttpContext context, string productKey)
        {
            if (!IsProductInCart(context, productKey))
            {
                return null;
            }

            var cart = Get(context);

            cart.FirstOrDefault(x => x.Key == productKey).Value.Count++;

            context.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

            return new ProductCountChangeServiceModel()
            {
                Count = cart.FirstOrDefault(x => x.Key == productKey).Value.Count,
                Total = cart.FirstOrDefault(x => x.Key == productKey).Value.Total
            };
        }

        public ProductCountChangeServiceModel? DecreaseProductCountById(HttpContext context, string productKey)
        {
            if (!IsProductInCart(context, productKey))
            {
                return null;
            }

            var cart = Get(context);

            var productCount = cart.FirstOrDefault(x => x.Key == productKey).Value.Count;

            if (productCount <= 1)
            {
                cart.Remove(productKey);

                context.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

                return null;
            }

            cart.FirstOrDefault(x => x.Key == productKey).Value.Count--;

            context.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

            return new ProductCountChangeServiceModel()
            {
                Count = cart.FirstOrDefault(x => x.Key == productKey).Value.Count,
                Total = cart.FirstOrDefault(x => x.Key == productKey).Value.Total
            };
        }
    }
}
