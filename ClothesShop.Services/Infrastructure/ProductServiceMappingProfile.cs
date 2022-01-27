namespace ClothesShop.Services.Infrastructure
{
    using AutoMapper;

    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models;
    using ClothesShop.Services.Models.Product;

    public class ProductServiceMappingProfile : Profile
    {
        public ProductServiceMappingProfile()
        {
            this.CreateMap<Product, ProductAllServiceModel>().ReverseMap();

            this.CreateMap<ProductAddServiceModel, Product>().ReverseMap();

            this.CreateMap<Size, ProductCheckSizeCollectionServiceModel>();

            this.CreateMap<Product, ProductCheckServiceModel>().
                ForMember(d => d.Sizes, cfg => cfg.MapFrom(src => src.Sizes));

            this.CreateMap<ProductCartServiceModel, ProductAndSizeServiceModel>();

            this.CreateMap<CartFormServiceModel, OrderRecipientDataModel>();
        }
    }
}
