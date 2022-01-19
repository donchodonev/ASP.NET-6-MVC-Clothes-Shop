namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Services;

    using System.ComponentModel.DataAnnotations;

    public class ProductsQueryFilter
    {
        public PriceOrder PriceOrder { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender GenderOptions { get; set; }

        public AgeGroup AgeOptions { get; set; }

        public RatingValue RatingOptions { get; set; }

        public IEnumerable<CategorySelectListItem> CategoryOptions { get; set; }

        public int CategoryId{ get; set; }

        public async Task CreateOptionsAsync(IProductService products)
        {
            CategoryOptions = await products.GetCategoriesAsync<CategorySelectListItem>();
        }
    }
}