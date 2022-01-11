namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.ValidationAttributes;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static ClothesShop.Data.DataConstants.Product;

    public class Product : ICreatable, IDeletable, IModifiable, IStockable
    {
        public Product()
        {
            CreatedOn = DateTime.Now;
            Ratings = new HashSet<Rating>();
        }

        [Required]
        public int Id { get; set; }

        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string Name { get; set; }

        [ValidPrice(Zero, DecimalMaxValue)]
        public decimal Price { get; set; }

        [Range(MinQuantity,MaxQuantity)]
        public int Quantity { get; set; }

        [NotMapped]
        public bool InStock => Quantity > 0;

        [Range(DescriptionMinLength,DescriptionMaxLength)]
        public string Description { get; set; }


        [Range(ManufacturerNameMinLength, ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; }

        public virtual ProductCategory Category { get; set; }

        public Size Size { get; set; }

        public GenderGroup GenderGroup { get; set; }

        public AgeGroup AgeGroup { get; set; }

        [Url]
        public string ImageURL { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount? Discount{ get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool? ModifiedOn { get; set; }
    }
}
