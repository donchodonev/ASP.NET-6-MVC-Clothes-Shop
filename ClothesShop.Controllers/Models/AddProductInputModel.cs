namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.ValidationAttributes;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants;

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

        public IEnumerable<CategorySelectListItem>? CategoryOptions { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<SizeSelectListItem>? SizeOptions { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int SizeId { get; set; }

        public IEnumerable<GenderGroupSelectListItem>? GenderGroupOptions { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int GenderGroupId { get; set; }

        public IEnumerable<AgeGroupSelectListItem>? AgeGroupOptions { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int AgeGroupId { get; set; }

        [Url]
        [Required]
        public string ImageURL { get; set; }
    }
}
