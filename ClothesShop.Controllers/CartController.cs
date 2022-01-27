namespace ClothesShop.Controllers
{
    using AutoMapper;

    using ClothesShop.Controllers.ActionFilters;
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    using static ClothesShop.Controllers.Infrastructure.ControllerExtensions;

    [EnsureCartExists]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class CartController : Controller
    {
        private readonly ICartService cart;
        private readonly IOrderService orders;
        private readonly IMapper mapper;

        public CartController(ICartService cart, IOrderService orders, IMapper mapper)
        {
            this.cart = cart;
            this.orders = orders;
            this.mapper = mapper;
        }

        public IActionResult Current()
        {
            var products = cart.Get(this.HttpContext).Values.ToList();

            return this.View(new CartFormServiceModel { Products = products });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CartFormServiceModel model)
        {
            var products = mapper.Map<List<ProductCartServiceModel>>(cart.Get(this.HttpContext).Values.Select(x => x));

            var validationResult = await cart.IsOrderValidAsync(this.HttpContext, products);

            if (!validationResult.IsValid)
            {
                return this.RedirectToActionWithTempData("Current", "Cart", "ErrorMessage", validationResult.Message);
            }

            if (!ModelState.IsValid)
            {
                return this.View(nameof(Current));
            }

            var productAndSizeIds = mapper.Map<ProductAndSizeServiceModel[]>(products);

            try
            {
                await orders.CreateOrderAsync(productAndSizeIds,
                    this.HttpContext,
                    model.Country,
                    model.City,
                    model.Street,
                    model.PostalCode);
            }
            catch (Exception ex)
            {
                return this.RedirectToActionWithTempData("Current", "Cart", "ErrorMessage", ex.Message);
            }

            return this.RedirectToAction(nameof(Current));
        }
    }
}
