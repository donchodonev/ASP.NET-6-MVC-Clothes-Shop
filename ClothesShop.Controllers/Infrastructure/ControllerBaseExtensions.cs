namespace ClothesShop.Controllers.Infrastructure
{
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;

    using System.Text.Json;

    using static ClothesShop.Data.Miscellaneous.DataConstants;

    public static class ControllerBaseExtensions
    {
        public static Dictionary<string, ProductCartModel> GetCart(this ControllerBase controller)
        {
            return JsonSerializer.Deserialize<Dictionary<string, ProductCartModel>>(controller.Request.Cookies[CartConstants.CookieKey]);
        }

        public static void AddToCart(this ControllerBase controller, ProductCartModel product)
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
    }
}
