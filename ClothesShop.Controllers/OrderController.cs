namespace ClothesShop.Controllers
{
    using ClothesShop.Controllers.Models;
    using ClothesShop.Services.Contracts;

    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        private readonly IOrderService orders;

        public OrderController(IOrderService orders)
        {
            var model = new OrderDetailsViewModel();
        }

        public IActionResult Details(string orderId)
        {
            return this.View();
        }
    }
}
