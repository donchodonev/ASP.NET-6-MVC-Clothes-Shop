namespace ClothesShop.Controllers.Infrastructure
{
    using Microsoft.AspNetCore.Mvc;

    public static class ControllerExtensions
    {
        public static IActionResult RedirectToActionWithTempData(this Controller controller, string actionName, string controllerName, string tempDataKey, object data)
        {
            controller.TempData[tempDataKey] = data;

            return controller.RedirectToAction(actionName, controller);
        }
    }
}
