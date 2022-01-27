namespace ClothesShop.Services.Models.Product
{
    using ClothesShop.Data.Entities;

    public class ProductAddServiceModel
    {
        public ProductAddServiceModel()
        {
            Sizes = new HashSet<Size>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public int GenderGroupId { get; set; }

        public int AgeGroupId { get; set; }

        public string ImageURL { get; set; }
    }
}
