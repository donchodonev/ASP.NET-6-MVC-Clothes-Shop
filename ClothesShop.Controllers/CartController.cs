namespace ClothesShop.Controllers
{
    using ClothesShop.Controllers.ActionFilters;

    using Microsoft.AspNetCore.Mvc;

    [EnsureCartExists]
    public class CartController : Controller
    {
        public CartController()
        {

        }

        public IActionResult Current()
        {
            return this.View();
        }
    }
}
