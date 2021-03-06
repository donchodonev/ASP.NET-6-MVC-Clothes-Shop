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
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string ImageURL { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}