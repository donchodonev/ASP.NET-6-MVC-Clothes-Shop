namespace ClothesShop.Services.Models.Product
{
    using ClothesShop.Data.Enums;

    public class ProductsServiceQueryFilter
    {
        public PriceOrder PriceOrder { get; set; }

        public int GenderId { get; set; }

        public int AgeGroupId { get; set; }

        public int RatingValue { get; set; }

        public int CategoryId { get; set; }

        public bool WithDeleted { get; set; }
    }
}
