namespace ClothesShop.Controllers.Models.Product
{
    public class ProductOrderDetailsViewModel
    {
        public int ProductId { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public string SizeText { get; set; }

        public decimal Total => Price * Count;

        public string ProductURL => $"/Products/Details?productId={ProductId}";
    }
}
