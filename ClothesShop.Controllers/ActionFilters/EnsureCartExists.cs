﻿namespace ClothesShop.Controllers.ActionFilters
{
    using ClothesShop.Controllers.Models;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using System.Text.Json;

    using static ClothesShop.Data.Miscellaneous.DataConstants;

    public class EnsureCartExists : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!CartExists(context))
            {
                CreateCart(context);
                context.Result = new RedirectToActionResult("Index", "Home", new object());
            }
        }

        private static bool CartExists(ActionExecutingContext context)
        {
            return context.HttpContext.Request.Cookies.ContainsKey(CartConstants.CookieKey);
        }

        private static void CreateCart(ActionExecutingContext context)
        {
            var emptyJsonObject = JsonSerializer.Serialize(new Dictionary<string, ProductCartModel>());

            context.HttpContext.Response.Cookies.Append(CartConstants.CookieKey, emptyJsonObject, CartConstants.CookieOptions);
        }
    }
}