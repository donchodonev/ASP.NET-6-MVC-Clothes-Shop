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
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Current()
        {
            var model = this.GetCart().Values.ToList();

            var products = mapper.Map<List<ProductCartServiceModel>>(this.GetCart().Values.Select(x => x));

            //remove async code after testing is finished
            await cartService.IsOrderValidAsync(products);

            return this.View(model);
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Order()
        {
            var products = mapper.Map<List<ProductCartServiceModel>>(this.GetCart().Values.Select(x => x));

            return this.View();
        }
    }
}
