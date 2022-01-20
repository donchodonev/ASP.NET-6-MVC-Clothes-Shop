namespace ClothesShop.Controllers
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;
    using ClothesShop.Services;
    using ClothesShop.Services.Models;

    using Microsoft.AspNetCore.Mvc;
    public class ProductsController : Controller
    {
        private readonly IProductService products;
        private readonly IMapper mapper;

        public ProductsController(IProductService products, IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
        }

        public async Task<IActionResult> All(AllProductsQueryInputModel inputModel)
        {
            var sourceFilter = inputModel.ExtractFilter();

            var queryFilter = mapper.Map<ProductsServiceQueryFilter>(sourceFilter);

            await inputModel.CreateOptionsAsync(products);

            await inputModel.GetTotalProductCountAsync(products, queryFilter);

            inputModel.Products = await products.AllAsyncPaginated<AllProductViewModel>(
                queryFilter,
                inputModel.ItemsPerPage,
                inputModel.CurrentPage);

            return View(inputModel);
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
