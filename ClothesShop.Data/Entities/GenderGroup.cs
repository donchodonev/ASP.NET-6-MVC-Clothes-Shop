namespace ClothesShop.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class GenderGroup
    {
        public GenderGroup()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}