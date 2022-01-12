namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.SizeConstants;

    public class Size
    {
        public Size()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Range(SizeNameMinLength, SizeNameMaxLength)]
        public string Value { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
