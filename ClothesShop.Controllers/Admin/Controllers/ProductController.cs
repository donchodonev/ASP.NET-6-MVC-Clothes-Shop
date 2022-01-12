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

        public ProductController(IProductService products, IGenderService genders)
        {
            this.products = products;
            this.genders = genders;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProductInputModel()
            {
                CategoryOptions = await products.GetCategoriesAsync<CategorySelectListItem>(),
                SizeOptions = await products.GetSizesAsync<SizeSelectListItem>(),
                GenderGroupOptions = await genders.All<GenderGroupSelectListItem>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductInputModel model)
        {

            if (!ModelState.IsValid)
            {
            }

            return RedirectToAction(nameof(Add));
        }
    }
}
