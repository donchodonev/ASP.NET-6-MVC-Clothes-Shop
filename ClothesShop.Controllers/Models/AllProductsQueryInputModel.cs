namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Services;

    using System.ComponentModel.DataAnnotations;

    public class AllProductsQueryInputModel
    {
        public AllProductsQueryInputModel()
        {
            CurrentPage = 1;
            ItemsPerPage = 12;
        }
        public IEnumerable<AllProductViewModel> Products { get; set; }

        public PriceOrder PriceOrder { get; set; }

        public Gender GenderOptions { get; set; }

        public AgeGroup AgeOptions { get; set; }

        public RatingValue RatingOptions { get; set; }

        public IEnumerable<CategorySelectListItem> CategoryOptions { get; set; }

        public int CategoryId { get; set; }

        public bool WithDeleted { get; set; }

        [Range(1, int.MaxValue)]
        public int CurrentPage { get; set; }

        [Range(1, int.MaxValue)]
        public int ItemsPerPage { get; set; }

        public int TotalItemCount { get; set; }

        public async Task CreateOptionsAsync(IProductService products)
        {
            CategoryOptions = await products.GetCategoriesAsync<CategorySelectListItem>();
        }

        public ProductsControllerQueryFilter ExtractFilter()
        {
            return new ProductsControllerQueryFilter()
            {
                PriceOrder = this.PriceOrder,
                GenderOptions = this.GenderOptions,
                AgeOptions = this.AgeOptions,
                RatingOptions = this.RatingOptions,
                CategoryOptions = this.CategoryOptions,
                CategoryId = this.CategoryId
            };
        }
    }
}