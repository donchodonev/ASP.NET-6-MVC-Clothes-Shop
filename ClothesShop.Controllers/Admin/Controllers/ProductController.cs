namespace ClothesShop.Web.Areas.Admin.Controllers
{
    using ClothesShop.Controllers.Models;
    using ClothesShop.Services;

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

        public ProductController(IProductService products, IGenderService genders, IAgeGroupService ageGroups)
        {
            this.products = products;
            this.genders = genders;
            this.ageGroups = ageGroups;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProductInputModel()
            {
                CategoryOptions = await products.GetCategoriesAsync<CategorySelectListItem>(),
                SizeOptions = await products.GetSizesAsync<SizeSelectListItem>(),
                GenderGroupOptions = await genders.All<GenderGroupSelectListItem>(),
                AgeGroupOptions = await ageGroups.All<AgeGroupSelectListItem>()
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

            return RedirectToAction(nameof(Add));
        }
    }
}
