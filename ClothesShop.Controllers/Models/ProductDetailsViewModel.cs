namespace ClothesShop.Controllers.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public string Manufacturer { get; set; }

        public IEnumerable<SizeWithQuantitySelectListItem> Sizes { get; set; }

        public int SizeId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
