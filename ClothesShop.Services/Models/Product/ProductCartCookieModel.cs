namespace ClothesShop.Services.Models.Product
{
    using ClothesShop.Data.ValidationAttributes;

    using System.ComponentModel.DataAnnotations;

    using static Data.Miscellaneous.DataConstants.ProductConstants;

    public class ProductCartCookieModel
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

        public string SizeText { get; set; }

        public decimal Total => Price * Count;

        public string ProductURL => $"/Products/Details?productId={ProductId}";
    }
}
