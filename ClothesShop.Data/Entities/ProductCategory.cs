namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;

    using Miscellaneous;

    using System.ComponentModel.DataAnnotations;

    using static Data.Miscellaneous.DataConstants.ProductCategoryConstants;

    public class ProductCategory : ICreatable, IModifiable, IDeletable
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public int Id { get; set; }

        [Range(NameMinLength, NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }
    }
}