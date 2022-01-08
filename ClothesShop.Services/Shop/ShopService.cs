using AutoMapper;

namespace ClothesShop.Services.Shop
{
    public class ShopService : IShopService
    {
        private readonly IMapper mapper;

        public ShopService(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
