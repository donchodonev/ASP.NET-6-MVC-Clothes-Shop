namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.GenderGroupConstants;

    public class GenderGroup
    {
        public GenderGroup()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Range(NameMinLength,NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}