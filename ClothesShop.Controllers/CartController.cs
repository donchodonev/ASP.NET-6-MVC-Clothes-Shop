namespace ClothesShop.Controllers
{
    using AutoMapper;

    using ClothesShop.Controllers.ActionFilters;
    using ClothesShop.Services;
    using ClothesShop.Services.Models;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    [EnsureCartExists]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class CartController : Controller
    {
        private readonly ICartService cart;
        private readonly IMapper mapper;

        public CartController(ICartService cart, IMapper mapper)
        {
            this.cart = cart;
            this.mapper = mapper;
        }

        public IActionResult Current()
        {
            var products = cart.Get(this.HttpContext).Values.ToList();

            return this.View(new CartFormServiceModel(products));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CartFormServiceModel model)
        {
            var products = mapper.Map<List<ProductCartServiceModel>>(cart.Get(this.HttpContext).Values.Select(x => x));

            var validationResult = await cart.IsOrderValidAsync(this.HttpContext, products);

            if (!validationResult.IsValid)
            {
                TempData["ErrorMessage"] = validationResult.Message;
                return this.RedirectToAction(nameof(Current));
            }

            if (!ModelState.IsValid)
            {
                return this.View(nameof(Current));
            }

            return this.RedirectToAction(nameof(Current));
        }
    }
}
