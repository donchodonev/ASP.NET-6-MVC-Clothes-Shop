﻿namespace ClothesShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ClientConstants;

    [Area("Admin")]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var check = this;
            return View();
        }
    }
}
