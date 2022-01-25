namespace ClothesShop.Web.Areas.Admin
{
    using AutoMapper;

    using ClothesShop.Controllers.Models.Product;
    using ClothesShop.Services;
    using ClothesShop.Services.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ClientConstants;

    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class ProductsController : Controller
    {
        private readonly IProductService products;
        private readonly IGenderService genders;
        private readonly IAgeGroupService ageGroups;
        private readonly IMapper mapper;

        public ProductsController(IProductService products,
            IGenderService genders,
            IAgeGroupService ageGroups,
            IMapper mapper)
        {
            this.products = products;
            this.genders = genders;
            this.ageGroups = ageGroups;
            this.mapper = mapper;
        }

        [HttpGet]
        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public async Task<IActionResult> Add()
        {
            var model = await new AddProductViewModel().CreateOptionsAsync(products, genders, ageGroups);

            return View(model);
        }

        [HttpPost]
        [ResponseCache(Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", await model.CreateOptionsAsync(products,genders,ageGroups));
            }

            //check if product exists already

            await products.AddAsync(mapper.Map<ProductAddServiceModel>(model));

            return RedirectToAction("Index", "Home");
        }
    }
}
