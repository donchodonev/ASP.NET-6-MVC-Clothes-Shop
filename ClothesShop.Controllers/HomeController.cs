namespace ClothesShop.Controllers
{
    using ClothesShop.Controllers.Models;
    using ClothesShop.Controllers.Models.Product;
    using ClothesShop.Services.Contracts;

    using Microsoft.AspNetCore.Mvc;

    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IGenderService genderGroups;
        private readonly IAgeGroupService ageGroups;

        public HomeController(IGenderService genderGroups, IAgeGroupService ageGroups)
        {
            this.genderGroups = genderGroups;
            this.ageGroups = ageGroups;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ProductGroupCollectionViewModel();

            await model.GetGroupsAsync(genderGroups, ageGroups);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}