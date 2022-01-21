namespace ClothesShop.Services
{
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models;

    public interface IProductService
    {
        public Task<TModel> GetByIdAsync<TModel>(int id) where TModel : class;

        public Task<IEnumerable<TModel>> AllAsync<TModel>(bool withDeleted = false) where TModel : class;

        public Task<IEnumerable<TModel>> AllAsyncPaginated<TModel>(ProductsServiceQueryFilter filter,int itemsPerPage,int currentPage) where TModel : class;

        public Task<int> AddAsync(ProductAddServiceModel model);

        public Task<IEnumerable<ProductCategory>> GetCategoriesAsync(bool withDeleted = false);

        public Task<IEnumerable<TModel>> GetCategoriesAsync<TModel>(bool withDeleted = false) where TModel : class;

        public Task<IEnumerable<Size>> GetSizesAsync();

        public Task<IEnumerable<TModel>> GetSizesAsync<TModel>() where TModel : class;

        public Task<int> CountFilteredAsync(ProductsServiceQueryFilter filter);
    }
}
