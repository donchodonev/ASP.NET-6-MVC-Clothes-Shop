namespace ClothesShop.Controllers.Models.Product
{
    using ClothesShop.Data.Enums;
    using ClothesShop.Services.Contracts;
    using ClothesShop.Services.Models.Product;

    public class AllProductsQueryViewModel
    {
        private int currentPage;

        public AllProductsQueryViewModel()
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

        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (value >= 1)
                {
                    currentPage = value;
                }
                else
                {
                    currentPage = 1;
                }
            }
        }

        public int ItemsPerPage { get; }

        public int TotalProductCount { get; set; }

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

        public async Task GetTotalProductCountAsync(IProductService products,ProductsServiceQueryFilter filter)
        {
            TotalProductCount = await products.CountFilteredAsync(filter);
        }
    }
}