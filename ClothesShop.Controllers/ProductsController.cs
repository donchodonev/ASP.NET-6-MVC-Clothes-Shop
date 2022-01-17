namespace ClothesShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        public ProductsController()
        {

        }

        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
