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
        private readonly IProductService data;

        public ProductController(IProductService data)
        {
            this.data = data;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProductInputModel()
            {
                CategoryOptions = await data.GetCategoriesAsync<CategorySelectListItem>(),
                Size = await data.GetSizesAsync<SizeSelectListItem>()
            };

            model.CategoryOptions.First().Selected = true;

            return View(model);
        }
    }
}
