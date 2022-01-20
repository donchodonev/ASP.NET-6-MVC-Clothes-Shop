namespace ClothesShop.Controllers.Infrastructure
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using System.Text.Json;

    public static class ControllerExtensions
    {
        public static void AddToCart(this Controller controller,object value)
        {
            var cookieOptions = new CookieOptions
            {
                // Set the secure flag, which Chrome's changes will require for SameSite none.
                // Note this will also require you to be running on HTTPS.
                Secure = true,

                // Set the cookie to HTTP only which is good practice unless you really do need
                // to access it client side in scripts.
                HttpOnly = true,

                // Add the SameSite attribute, this will emit the attribute with a value of none.
                // To not emit the attribute at all set
                // SameSite = (SameSiteMode)(-1)
                SameSite = SameSiteMode.Lax
            };

            var cookieKey = "ClothesShopShoppingCart";

            var objectJson = JsonSerializer.Serialize(value);

            controller.Response.Cookies.Append(cookieKey, objectJson, cookieOptions);
        }
    }
}
