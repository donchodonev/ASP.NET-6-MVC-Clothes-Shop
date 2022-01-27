namespace ClothesShop.Controllers
{
    using AutoMapper;

    using ClothesShop.Controllers.ActionFilters;
    using ClothesShop.Services;
    using ClothesShop.Services.Models;

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
            var model = cart.Get(this.HttpContext).Values.ToList();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var products = mapper.Map<List<ProductCartServiceModel>>(cart.Get(this.HttpContext).Values.Select(x => x));

            var validationResult = await cart.IsOrderValidAsync(products);

            if (!validationResult.IsValid)
            {
                TempData["ErrorMessage"] = validationResult.Message;
                return this.RedirectToAction(nameof(Current));
            }

            Console.WriteLine(validationResult.IsValid);
            Console.WriteLine(validationResult.Message);
            Console.WriteLine(validationResult.ProductId);

            return this.RedirectToAction(nameof(Current));
        }
    }
}
