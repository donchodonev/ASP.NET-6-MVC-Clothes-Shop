namespace ClothesShop.Data.Entities
{

    using System.ComponentModel.DataAnnotations;

    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Products = new HashSet<Product>();
        }

        [Required]
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}