namespace ClothesShop.Controllers.Models
{
    public class AllProductsQueryInputModel
    {
        public IEnumerable<AllProductViewModel> Products { get; set; }

        public ProductsQueryFilter Filter { get; set; }
    }
}
