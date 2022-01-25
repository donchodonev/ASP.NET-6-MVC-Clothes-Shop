namespace ClothesShop.Controllers.Infrastructure
{
    using ClothesShop.Controllers.Models.Product;

    using Microsoft.AspNetCore.Mvc;

    using System.Text.Json;

    using static ClothesShop.Data.Miscellaneous.DataConstants;

    public static class ControllerBaseExtensions
    {
        public static Dictionary<string, ProductCartCookieModel> GetCart(this ControllerBase controller)
        {
            try
            {
                return JsonSerializer.Deserialize<Dictionary<string, ProductCartCookieModel>>(controller.Request.Cookies[CartConstants.CookieKey]);
            }
            catch (Exception)
            {
                ClearCart(controller);
                return new Dictionary<string, ProductCartCookieModel>();
            }
        }

        public static void AddToCart(this ControllerBase controller, ProductCartCookieModel product)
        {
            var cart = GetCart(controller);

            var productKey = $"{product.ProductId}:{product.SizeId}";

            if (cart.ContainsKey(productKey))
            {
                cart[productKey].Count += product.Count;
            }
            else
            {
                cart.Add(productKey, product);
            }

            controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);
        }

        public static int UniqueProductsCount(this ControllerBase controller)
        {
            return GetCart(controller).Values.Where(x => x.Count > 0).Count();
        }

        public static bool IsProductInCart(this ControllerBase controller, string productKey)
        {
            return GetCart(controller).Keys.Any(x => x == productKey);
        }

        public static void ClearCart(this ControllerBase controller)
        {
            var emptyCart = new Dictionary<string, ProductCartCookieModel>();

            controller.Response.Cookies.Delete(CartConstants.CookieKey);

            controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(emptyCart), CartConstants.CookieOptions);
        }

        public static ProductCountChangeResponseModel? IncreaseProductCountById(this ControllerBase controller, string productKey)
        {
            if (!IsProductInCart(controller, productKey))
            {
                return null;
            }

            var cart = GetCart(controller);

            cart.FirstOrDefault(x => x.Key == productKey).Value.Count++;

            controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

            return new ProductCountChangeResponseModel()
            {
                Count = cart.FirstOrDefault(x => x.Key == productKey).Value.Count,
                Total = cart.FirstOrDefault(x => x.Key == productKey).Value.Total
            };
        }

        public static ProductCountChangeResponseModel? DecreaseProductCountById(this ControllerBase controller, string productKey)
        {
            if (!IsProductInCart(controller, productKey))
            {
                return null;
            }

            var cart = GetCart(controller);

            var productCount = cart.FirstOrDefault(x => x.Key == productKey).Value.Count;

            if (productCount <= 1)
            {
                cart.Remove(productKey);

                controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

                return null;
            }

            cart.FirstOrDefault(x => x.Key == productKey).Value.Count--;

            controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

            return new ProductCountChangeResponseModel()
            {
                Count = cart.FirstOrDefault(x => x.Key == productKey).Value.Count,
                Total = cart.FirstOrDefault(x => x.Key == productKey).Value.Total
            };
        }
    }
}