namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.Entities;
    using ClothesShop.Data.ValidationAttributes;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ProductConstants;

    public class AddProductInputModel
    {
        [Required]
        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Price(Zero, DecimalMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; }

        [Range(DescriptionMinLength, DescriptionMaxLength)]
        public string Description { get; set; }

        [Range(ManufacturerNameMinLength, ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; }

        [Required]
        public IEnumerable<CategorySelectListItem> CategoryOptions { get; set; }

        [Required]
        public IEnumerable<SizeSelectListItem> Size { get; set; }

        public GenderGroup GenderGroup { get; set; }

        [Required]
        public AgeGroup AgeGroup { get; set; }

        [Url]
        [Required]
        public string ImageURL { get; set; }
    }
}
