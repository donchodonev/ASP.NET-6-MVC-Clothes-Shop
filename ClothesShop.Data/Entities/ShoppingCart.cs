namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;

    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart :ICreatable, IModifiable, IDeletable
    {
        public ShoppingCart()
        {
            Products = new HashSet<Product>();
            CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}