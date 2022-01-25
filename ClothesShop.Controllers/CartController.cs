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

        public IActionResult Current()
        {
            var model = this.GetCart().Values.ToList();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Order()
        {
            var products = mapper.Map<List<ProductCartServiceModel>>(this.GetCart().Values.Select(x => x));

            return this.View();
        }
    }
}
