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

        public async Task<IEnumerable<TModel>> All<TModel>(bool withDeleted = false) where TModel : class
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

        public async Task<int> Add(ProductAddServiceModel model)
        {
            var product = mapper.Map<Product>(model);

            db.Products.Add(product);

            return product.Id;
        }
    }
}
