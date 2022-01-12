namespace ClothesShop.Web.Areas.Admin.Controllers
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;
    using ClothesShop.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Collections.Generic;

    using static ClothesShop.Data.DataConstants.ClientConstants;

    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductService data;
        private readonly IMapper mapper;

        public ProductController(IProductService data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await data.GetCategoriesAsync();

            var categoriesSelectList = mapper.Map<IEnumerable<SelectListItem>>(categories);

            categoriesSelectList.First().Selected = true;

            var model = new AddProductInputModel();

            model.CategoryOptions = categoriesSelectList;

            return View(model);
        }
    }
}
