namespace ClothesShop.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using ClothesShop.Data;
    using ClothesShop.Data.Entities;
    using ClothesShop.Data.Enums;
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
            return await db
                .Products
                .Where(x => x.IsDeleted == withDeleted)
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id) where TModel : class
        {
            return await db
                .Products
                .Where(x => x.Id == id)
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CountFilteredAsync(ProductsServiceQueryFilter filter)
        {
            var query = db.Products.AsQueryable();

            query = FilterResults(query, filter);

            query = SortResults(query, filter.PriceOrder);

            return await query.CountAsync();
        }

        public async Task<IEnumerable<TModel>> AllAsyncPaginated<TModel>(
            ProductsServiceQueryFilter filter,
            int itemsPerPage,
            int currentPage) where TModel : class
        {
            var query = db.Products.AsQueryable();

            query = FilterResults(query, filter);

            query = SortResults(query, filter.PriceOrder);

            query = ApplyPagination(query, itemsPerPage, currentPage);

            return await query
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<int> AddAsync(ProductAddServiceModel model)
        {
            var zeroCountSizes = model.Sizes.Where(x => x.Count == 0);

            model.Sizes = model.Sizes.Except(zeroCountSizes).ToList();

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

        private IQueryable<TModel> ApplyPagination<TModel>(IQueryable<TModel> entitiesQuery,
            int itemsPerPage,
            int currentpage) where TModel : class
        {
            return entitiesQuery
                .Skip((currentpage - 1) * itemsPerPage)
                .Take(itemsPerPage);
        }

        private IQueryable<Product> FilterResults(
            IQueryable<Product> query,
            ProductsServiceQueryFilter filter)
        {
            query = query.Where(x => x.IsDeleted == filter.WithDeleted);

            query = filter.AgeGroupId == 0 ? query : query.Where(x => x.AgeGroupId == filter.AgeGroupId);
            query = filter.CategoryId == 0 ? query : query.Where(x => x.CategoryId == filter.CategoryId);
            query = filter.GenderId == 0 ? query : query.Where(x => x.GenderGroupId == filter.GenderId);
            query = filter.RatingValue == 0 ? query : query.Where(x => (int)x.Ratings.Average(y => (int)y.Value.Value) >= filter.RatingValue);

            return query;
        }

        private IQueryable<Product> SortResults(
    IQueryable<Product> query,
    PriceOrder filter)
        {
            switch (filter)
            {
                case PriceOrder.Price:
                    query = query.OrderByDescending(x => x.CreatedOn);
                    break;
                case PriceOrder.Ascending:
                    query = query.OrderBy(x => x.Price);
                    break;
                case PriceOrder.Descending:
                    query = query.OrderByDescending(x => x.Price);
                    break;
            }

            return query;
        }
    }
}
