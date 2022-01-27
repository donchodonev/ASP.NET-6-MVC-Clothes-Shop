namespace ClothesShop.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using ClothesShop.Data;

    using Microsoft.EntityFrameworkCore;

    using ClothesShop.Services.Contracts;

    public class AgeGroupService : IAgeGroupService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public AgeGroupService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> AllAsync<TModel>() where TModel : class
        {
            return await data
                .AgeGroups
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
