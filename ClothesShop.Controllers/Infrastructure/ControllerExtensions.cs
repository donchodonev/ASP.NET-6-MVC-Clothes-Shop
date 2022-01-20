namespace ClothesShop.Controllers.Infrastructure
{
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using System.Text.Json;

    public static class ControllerExtensions
    {
        private const string CookieKey = "ClothesShopShoppingCart";

        public static void AddToCart(this Controller controller, object value)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.Lax
            };

            var product = (ProductCartModel)value;

            var objectJson = JsonSerializer.Serialize(new Dictionary<int, ProductCartModel>() { { product.Id, product } });

            controller.Response.Cookies.Append(CookieKey, objectJson, cookieOptions);
        }

        public static Dictionary<int, ProductCartModel> GetCart(this Controller controller)
        {
            return JsonSerializer.Deserialize<Dictionary<int, ProductCartModel>>(controller.Request.Cookies[CookieKey]);
        }
    }
}
