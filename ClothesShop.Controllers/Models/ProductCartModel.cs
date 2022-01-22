namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.ValidationAttributes;

    using System.ComponentModel.DataAnnotations;

    using static Data.Miscellaneous.DataConstants.ProductConstants;

    public class ProductCartModel
    {
        [Required]
        public int ProductId { get; set; }

        [Url]
        [Required]
        public string ImageURL { get; set; }

        [Price(ProductMinPrice,ProductMaxPrice)]
        public decimal Price { get; set; }

        [Range(1,int.MaxValue)]
        public int Count { get; set; }

        public int SizeId { get; set; }

        public decimal Total { get; set; }
    }
}
