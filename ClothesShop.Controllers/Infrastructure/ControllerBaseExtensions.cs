namespace ClothesShop.Controllers.Infrastructure
{
    using ClothesShop.Controllers.Models;
    using ClothesShop.Data.Miscellaneous;

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
            SameSite = SameSiteMode.Lax,
            MaxAge = DateTimeProvider.CookieMaxAge,
            IsEssential = true
        };

        public static void CreateCart(this ControllerBase controller)
        {
            var emptyJsonObject = JsonSerializer.Serialize(new Dictionary<string, ProductCartModel>());

            controller.Response.Cookies.Append(CookieKey, emptyJsonObject, CookieOptions);
        }

        public static Dictionary<string, ProductCartModel> GetCart(this ControllerBase controller)
        {
            return JsonSerializer.Deserialize<Dictionary<string, ProductCartModel>>(controller.Request.Cookies[CookieKey]);
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

            controller.Response.Cookies.Append(CookieKey, JsonSerializer.Serialize(cart), CookieOptions);
        }

        public static bool CartExists(this ControllerBase controller)
        {
            return controller.Request.Cookies.ContainsKey(CookieKey);
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
