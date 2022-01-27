namespace ClothesShop.Controllers
{
    using AutoMapper;

    using ClothesShop.Controllers.ActionFilters;
    using ClothesShop.Services;
    using ClothesShop.Services.Models;

    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    using static ClothesShop.Controllers.Infrastructure.ControllerBaseExtensions;

    [EnsureCartExists]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }

        public IActionResult Current()
        {
            var model = this.GetCart().Values.ToList();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var products = mapper.Map<List<ProductCartServiceModel>>(this.GetCart().Values.Select(x => x));

            var validationResult = await cartService.IsOrderValidAsync(products);

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
