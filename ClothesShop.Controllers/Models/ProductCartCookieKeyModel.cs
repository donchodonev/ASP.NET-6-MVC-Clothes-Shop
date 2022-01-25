namespace ClothesShop.Controllers.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCartCookieKeyModel
    {
        [RegularExpression(@"^[0-9]{1,2}:[0-9]{1,2}$")]
        public string Key { get; set; }
    }
}
