namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.Entities;
    using ClothesShop.Data.ValidationAttributes;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants;
    using static ClothesShop.Data.Miscellaneous.DataConstants.ProductCategoryConstants;
    using static ClothesShop.Data.Miscellaneous.DataConstants.SizeConstants;

    public class AddProductInputModel
    {
        [Required]
        [MaxLength(ProductConstants.ProductNameMaxLength)]
        [MinLength(ProductConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Price(ProductConstants.Zero, ProductConstants.DecimalMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(ProductConstants.MinQuantity, ProductConstants.MaxQuantity)]
        public int Quantity { get; set; }

        [Required]
        [MinLength(ProductConstants.DescriptionMinLength)]
        [MaxLength(ProductConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(ProductConstants.ManufacturerNameMinLength)]
        [MaxLength(ProductConstants.ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; }

        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public IEnumerable<CategorySelectListItem>? CategoryOptions { get; set; }

        [Required]
        public string Category { get; set; }

        [StringLength(SizeNameMaxLength, MinimumLength = SizeNameMinLength)]
        public IEnumerable<SizeSelectListItem>? SizeOptions { get; set; }

        [Required]
        public string Size { get; set; }

        public IEnumerable<GenderGroupSelectListItem>? GenderGroupOptions { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Gender { get; set; }

        [Required]
        public AgeGroup AgeGroup { get; set; }

        [Url]
        [Required]
        public string ImageURL { get; set; }
    }
}
