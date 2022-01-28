namespace ClothesShop.Services.Models.Product
{
    using ClothesShop.Data.Entities;
    using ClothesShop.Data.ValidationAttributes;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ProductConstants;

    public class ProductAllServiceModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string Name { get; set; }

        [Price(ProductMinPrice, ProductMaxPrice)]
        public decimal Price { get; set; }

        [Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; }

        [MaxLength(DescriptionMinLength)]
        [MinLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [MaxLength(ManufacturerNameMinLength)]
        [MinLength(ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; }

        public  ProductCategory Category { get; set; }

        public Size Size { get; set; }

        public GenderGroup GenderGroup { get; set; }

        public AgeGroup AgeGroup { get; set; }

        public string ImageURL { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual Discount? Discount { get; set; }
    }
}
