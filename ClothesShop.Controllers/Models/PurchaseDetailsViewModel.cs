namespace ClothesShop.Controllers.Models
{
    public class PurchaseDetailsViewModel
    {
        public int ProductId { get; set; }

        public string ImageURL { get; set; }

        public string ProductURL => $"/Products/Details?productId={ProductId}";

        public decimal Price { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice => Price * Count;

        public string SizeText { get; set; }
    }
}
