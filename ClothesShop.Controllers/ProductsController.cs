namespace ClothesShop.Controllers
{
    using ClothesShop.Controllers.Models;
    using ClothesShop.Services;

    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly IProductService products;

        public ProductsController(IProductService products)
        {
            this.products = products;
        }

        public async Task<IActionResult> All(AllProductsQueryInputModel inputModel)
        {
            inputModel.Filter ??= new ProductsQueryFilter();
            await inputModel.Filter.CreateOptionsAsync(products);

            inputModel.Products = await products.AllAsync<AllProductViewModel>();

            return View(inputModel);
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
