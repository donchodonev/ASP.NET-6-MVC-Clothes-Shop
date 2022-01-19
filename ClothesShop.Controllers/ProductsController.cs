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

        public ProductsController(IProductService products,IMapper mapper)
        {
            this.products = products;
            this.mapper = mapper;
        }

        public async Task<IActionResult> All(AllProductsQueryInputModel inputModel)
        {
            inputModel.Filter ??= new ProductsControllerQueryFilter();

            var queryFilter = mapper.Map<ProductsServiceQueryFilter>(inputModel.Filter);

            await inputModel.Filter.CreateOptionsAsync(products);

            inputModel.Products = await products.AllAsync<AllProductViewModel>(queryFilter);

            return View(inputModel);
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
