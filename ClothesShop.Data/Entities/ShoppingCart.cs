namespace ClothesShop.Data.Entities
{

    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart
    {
        [Required]
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual Client Client { get; set; }
    }
}