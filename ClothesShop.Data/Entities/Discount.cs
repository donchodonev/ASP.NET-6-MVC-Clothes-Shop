namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;

    using Miscellaneous;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.DiscountConstants;

    public class Discount : ICreatable, IDeletable, IModifiable
    {
        public Discount()
        {
            Products = new HashSet<Product>();
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Range(PercentageMinValue, PercentageMaxValue)]
        public int Percentage { get; set; }

        public ProductCategory? ProductCategory { get; set; }

        public AgeGroup? AgeGroup { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public DateTime CreatedOn { get ; set ; }

        public bool IsDeleted { get; set; }

        public bool? ModifiedOn { get; set; }
    }
}
