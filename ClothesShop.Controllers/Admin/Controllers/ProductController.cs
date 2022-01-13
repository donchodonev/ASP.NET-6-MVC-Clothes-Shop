﻿namespace ClothesShop.Web.Areas.Admin.Controllers
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
    [ResponseCache(NoStore = true)]
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
            var model = await new AddProductInputModel().CreateAsync(products, genders, ageGroups);

            return View(model);
        }

        [HttpPost]
        [ResponseCache(NoStore = true)]
        public async Task<IActionResult> Add(AddProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            //check if product exists already

            await products.AddAsync(mapper.Map<ProductAddServiceModel>(model));

            return RedirectToAction("Index", "Home");
        }
    }
}
