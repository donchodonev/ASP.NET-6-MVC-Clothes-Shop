namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.AgeGroupConstants;

    public class AgeGroup
    {
        public AgeGroup()
        {
            Clients = new HashSet<Client>();
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Required]
        public string Name { get; set; }

        [Url]
        public string ImageURL { get; set; }

        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
