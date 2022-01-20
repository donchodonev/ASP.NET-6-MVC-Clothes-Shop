namespace ClothesShop.Controllers.Infrastructure
{
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using System.Text.Json;

    public static class ControllerBaseExtensions
    {
        private const string CookieKey = "ClothesShopShoppingCart";

        private static CookieOptions CookieOptions = new CookieOptions
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.Lax
        };

        public static void CreateCart(this ControllerBase controller)
        {
            var emptyJsonObject = JsonSerializer.Serialize(new Dictionary<int, ProductCartModel>());

            controller.Response.Cookies.Append(CookieKey, emptyJsonObject, CookieOptions);
        }

        public static Dictionary<int, ProductCartModel> GetCart(this ControllerBase controller)
        {
            return JsonSerializer.Deserialize<Dictionary<int, ProductCartModel>>(controller.Request.Cookies[CookieKey]);
        }

        public static void AddToCart(this ControllerBase controller, ProductCartModel product)
        {
            var cart = GetCart(controller);

            if (cart.ContainsKey(product.Id))
            {
                cart[product.Id].Count++;
            }
            else
            {
                product.Count = 1;
                cart.Add(product.Id, product);
            }

            controller.Response.Cookies.Append(CookieKey, JsonSerializer.Serialize(cart), CookieOptions);
        }

        public static bool CartExists(this ControllerBase controller)
        {
            return controller.Request.Cookies.ContainsKey(CookieKey);
        }
    }
}
