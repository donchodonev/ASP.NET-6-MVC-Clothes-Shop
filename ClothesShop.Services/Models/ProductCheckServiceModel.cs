namespace ClothesShop.Services.Models
{
    public class ProductCheckServiceModel
    {
        public ProductCheckServiceModel()
        {
            Sizes = new HashSet<ProductCheckSizeCollectionServiceModel>();
        }
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public ICollection<ProductCheckSizeCollectionServiceModel> Sizes { get; set; }
    }
}
