namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;
    using ClothesShop.Data.ValidationAttributes;

    using Miscellaneous;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ProductConstants;

    public class Product : ICreatable, IDeletable, IModifiable
    {
        public Product()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
            Ratings = new HashSet<Rating>();
            Sizes = new HashSet<Size>();
        }

        [Required]
        public int Id { get; set; }

        [MaxLength(ProductNameMaxLength)]
        [MinLength(ProductNameMinLength)]
        public string Name { get; set; }

        [Price(Zero, DecimalMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [NotMapped]
        public int Quantity => Sizes.Sum(x => x.Count);

        [Range(DescriptionMinLength,DescriptionMaxLength)]
        public string Description { get; set; }


        [Range(ManufacturerNameMinLength, ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }

        public virtual ICollection<Size> Sizes { get; set; }

        [Required]
        public int GenderGroupId { get; set; }

        public virtual GenderGroup GenderGroup { get; set; }

        [Required]
        public int AgeGroupId { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }

        [Url]
        [Required]
        public string ImageURL { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount? Discount{ get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool? ModifiedOn { get; set; }
    }
}
