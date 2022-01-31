namespace ClothesShop.Controllers
{
    using ClothesShop.Controllers.Models;
    using ClothesShop.Services.Contracts;

    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        private readonly IOrderService orders;
        private readonly IProductService products;

        public OrderController(IOrderService orders, IProductService products)
        {
            this.orders = orders;
            this.products = products;
        }

        public async Task<IActionResult> Details(string orderId)
        {
            if (orderId == null)
            {
                return this.BadRequest();
            }

            var model = new PurchaseDataModel();

            await model.PopulateModelAsync(orders, products, orderId);

            return this.View(model);
        }
    }
}
