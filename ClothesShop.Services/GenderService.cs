namespace ClothesShop.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using ClothesShop.Data;
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models;

    using Microsoft.EntityFrameworkCore;

    public class GenderService : IGenderService
    {
        private readonly ShopDbContext data;
        private readonly IMapper mapper;

        public GenderService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> All<TModel>() where TModel : class
        {
            return await data
                .GenderGroups
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<GenderGroupServiceModel>> All()
        {
            return await data
                .GenderGroups
                .AsQueryable()
                .ProjectTo<GenderGroupServiceModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
