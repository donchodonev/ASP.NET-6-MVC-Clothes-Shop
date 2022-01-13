namespace ClothesShop.Services.Models
{
    public class ProductAddServiceModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public int CategoryId { get; set; }

        public int SizeId { get; set; }

        public int GenderGroupId { get; set; }

        public int AgeGroupId { get; set; }

        public string ImageURL { get; set; }
    }
}
