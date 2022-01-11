namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.ProductCategory;

    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Range(NameMinLength, NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}