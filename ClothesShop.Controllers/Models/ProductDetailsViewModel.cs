using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Controllers.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel()
        {
            QuantityValue = 1;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public string Manufacturer { get; set; }

        public IEnumerable<SizeWithQuantitySelectListItem> Sizes { get; set; }

        public int SizeId { get; set; }

        [RegularExpression(@"[0-9]+", ErrorMessage = "Quantity must be a positive integer number")]
        [Range(1,int.MaxValue, ErrorMessage = "Quantity must be a positive integer number")]
        public int QuantityValue { get; set; }

        public decimal Price { get; set; }

        public decimal Total => Price * QuantityValue;
    }
}
