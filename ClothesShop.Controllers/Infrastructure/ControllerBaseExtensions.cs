namespace ClothesShop.Controllers.Infrastructure
{
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;

    using System.Text.Json;

    using static ClothesShop.Data.Miscellaneous.DataConstants;

    public static class ControllerBaseExtensions
    {
        public static Dictionary<string, ProductCartCookieModel> GetCart(this ControllerBase controller)
        {
            return JsonSerializer.Deserialize<Dictionary<string, ProductCartCookieModel>>(controller.Request.Cookies[CartConstants.CookieKey]);
        }

        public static void AddToCart(this ControllerBase controller, ProductCartCookieModel product)
        {
            var cart = GetCart(controller);

            var productKey = $"{product.ProductId}:{product.SizeId}";

            if (cart.ContainsKey(productKey))
            {
                cart[productKey].Count+=product.Count;
                cart[productKey].Total += product.Total;
            }
            else
            {
                cart.Add(productKey, product);
            }

            controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);
        }

        public static int UniqueProductsCount(this ControllerBase controller)
        {
            return GetCart(controller).Values.Count();
        }

        public static bool IsProductInCart(this ControllerBase controller, string productKey)
        {
            return GetCart(controller).Keys.Any(x => x == productKey);
        }

        public static int? IncreaseProductCountById(this ControllerBase controller, string productKey)
        {
            if (!IsProductInCart(controller,productKey))
            {
                return null;
            }

            var cart = GetCart(controller);

            cart.FirstOrDefault(x => x.Key == productKey).Value.Count++;

            controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

            return cart.FirstOrDefault(x => x.Key == productKey).Value.Count;
        }

        public static int? DecreaseProductCountById(this ControllerBase controller, string productKey)
        {
            if (!IsProductInCart(controller, productKey))
            {
                return null;
            }

            var cart = GetCart(controller);

            cart.FirstOrDefault(x => x.Key == productKey).Value.Count--;

            controller.Response.Cookies.Append(CartConstants.CookieKey, JsonSerializer.Serialize(cart), CartConstants.CookieOptions);

            return cart.FirstOrDefault(x => x.Key == productKey).Value.Count;
        }
    }
}
