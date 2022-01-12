namespace ClothesShop.Services
{
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models;

    public interface IProductService
    {
        public Task<IEnumerable<TModel>> AllAsync<TModel>(bool withDeleted = false) where TModel : class;

        public Task<int> AddAsync(ProductAddServiceModel model);

        public Task<IEnumerable<ProductCategory>> GetCategoriesAsync(bool withDeleted = false);
    }
}
