namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.DataConstants.SizeConstants;

    public class Size
    {
        public Size()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Range(SizeNameMinLength,SizeNameMaxLength)]

        public virtual ICollection<Product> Products { get; set; }
    }
}
