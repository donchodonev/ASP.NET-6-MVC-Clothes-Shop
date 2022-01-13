namespace ClothesShop.Web.Areas.Admin.Controllers
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;
    using ClothesShop.Services;
    using ClothesShop.Services.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ClientConstants;

    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductService products;
        private readonly IGenderService genders;
        private readonly IAgeGroupService ageGroups;
        private readonly IMapper mapper;

        public ProductController(IProductService products,
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
        public async Task<IActionResult> Add()
        {
            var model = new AddProductInputModel()
            {
                CategoryOptions = await products.GetCategoriesAsync<CategorySelectListItem>(),
                SizeOptions = await products.GetSizesAsync<SizeSelectListItem>(),
                GenderGroupOptions = await genders.AllAsync<GenderGroupSelectListItem>(),
                AgeGroupOptions = await ageGroups.AllAsync<AgeGroupSelectListItem>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await products.AddAsync(mapper.Map<ProductAddServiceModel>(model));

            return RedirectToAction(nameof(Add));
        }
    }
}
