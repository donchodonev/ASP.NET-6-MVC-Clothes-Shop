namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Data.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static ClothesShop.Data.DataConstants;

    public class Product : ICreatable, IDeletable, IModifiable, IStockable
    {
        public Product()
        {
            CreatedOn = DateTime.Now;
        }

        [Required]
        public int Id { get; set; }

        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public bool InStock => Quantity > 0;

        [NotMapped]
        public int TotalDiscountPercentage => Category.DiscountPercentage + AgeGroup.DiscountPercentage;

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public ProductCategory Category { get; set; }

        public Size Size { get; set; }

        public Gender Gender { get; set; }

        public AgeGroup AgeGroup { get; set; }

        public Rating Rating { get; set; }

        public string ImageURL { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool? ModifiedOn { get; set; }
    }
}
