namespace ClothesShop.Controllers
{
    using ClothesShop.Services.Contracts;

    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        private readonly IOrderService orders;

        public OrderController(IOrderService orders)
        {
            this.orders = orders;
        }

        public IActionResult Details(string orderId)
        {
            return this.View();
        }
    }
}
