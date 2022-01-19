namespace ClothesShop.Controllers.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AllProductsQueryInputModel
    {
        public AllProductsQueryInputModel()
        {
            Filter ??= new ProductsControllerQueryFilter();
            CurrentPage = 1;
            ItemsPerPage = 12;
        }
        public IEnumerable<AllProductViewModel> Products { get; set; }

        public ProductsControllerQueryFilter Filter { get; set; }

        [Range(1, int.MaxValue)]
        public int CurrentPage { get; set; }

        [Range(1, int.MaxValue)]
        public int ItemsPerPage { get; set; }

        public int TotalItemCount { get; set; }
    }
}
