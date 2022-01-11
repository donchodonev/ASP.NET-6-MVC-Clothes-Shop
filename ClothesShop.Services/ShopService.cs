namespace ClothesShop.Services
{
    using AutoMapper;

    public class ShopService : IShopService
    {
        private readonly IMapper mapper;

        public ShopService(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
