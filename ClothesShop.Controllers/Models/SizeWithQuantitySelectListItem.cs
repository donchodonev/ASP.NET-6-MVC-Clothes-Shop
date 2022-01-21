namespace ClothesShop.Controllers.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class SizeWithQuantitySelectListItem : SelectListItem
    {
        public int Id { get; set; }

        public int Count { get; set; }
    }
}
