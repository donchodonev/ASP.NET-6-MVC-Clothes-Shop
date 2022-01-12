namespace ClothesShop.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using ClothesShop.Data;
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models;

    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly ShopDbContext db;
        private readonly IMapper mapper;

        public ProductService(ShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> AllAsync<TModel>(bool withDeleted = false) where TModel : class
        {
            var query = db.Products.AsQueryable();

            if (withDeleted)
            {
                query = query.Where(x => x.IsDeleted);
            }

            return await query
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<int> AddAsync(ProductAddServiceModel model)
        {
            var product = mapper.Map<Product>(model);

            await db.Products.AddAsync(product);

            await db.SaveChangesAsync();

            return product.Id;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync(bool withDeleted = false)
        {
            var query = db.ProductCategories.AsQueryable();

            if (withDeleted)
            {
                query = query.Where(x => x.IsDeleted);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetCategoriesAsync<TModel>(bool withDeleted = false) where TModel : class
        {
            var query = db.ProductCategories.AsQueryable();

            if (withDeleted)
            {
                query = query.Where(x => x.IsDeleted);
            }

            return await query
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Size>> GetSizesAsync()
        {
            return await db.Sizes.ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetSizesAsync<TModel>() where TModel : class
        {
            return await db
                .Sizes
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
