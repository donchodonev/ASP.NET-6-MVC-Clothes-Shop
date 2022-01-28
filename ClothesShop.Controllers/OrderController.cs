namespace ClothesShop.Controllers
{
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        private readonly IOrderService orders;

        public OrderController(IOrderService orders)
        {
            var model = new List<ProductCartCookieModel>();
        }

        public IActionResult Details(string orderId)
        {
            return this.View();
        }
    }
}
