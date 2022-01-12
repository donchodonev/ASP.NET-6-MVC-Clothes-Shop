namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.Entities;
    using ClothesShop.Data.ValidationAttributes;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.DataConstants.ProductConstants;

    public class AddProductInputModel
    {
        [Required]
        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string Name { get; set; }

        [ValidPrice(Zero, DecimalMaxValue)]
        public decimal Price { get; set; }

        [Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; }

        [Range(DescriptionMinLength, DescriptionMaxLength)]
        public string Description { get; set; }

        [Range(ManufacturerNameMinLength, ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; }

        public IEnumerable<SelectListItem> CategoryOptions { get; set; }

        public string Category { get; set; }

        public Size Size { get; set; }

        public GenderGroup GenderGroup { get; set; }

        [Required]
        public AgeGroup AgeGroup { get; set; }

        [Url]
        [Required]
        public string ImageURL { get; set; }
    }
}
