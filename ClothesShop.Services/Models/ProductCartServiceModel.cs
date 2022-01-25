namespace ClothesShop.Services.Models
{
    public class ProductCartServiceModel
    {
        public int ProductId { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public int SizeId { get; set; }

        public decimal Total { get; set; }
    }
}
