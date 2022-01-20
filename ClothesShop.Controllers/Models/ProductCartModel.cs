namespace ClothesShop.Controllers.Models
{
    public class ProductCartModel
    {
        public int Id { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
