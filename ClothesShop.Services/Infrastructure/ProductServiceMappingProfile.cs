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

            this.CreateMap<GenderGroup, ProductGroupServiceModel>()
                .ForMember(d => d.Type, cfg => cfg.MapFrom(src => src.GetType().Name.Substring(0, src.GetType().Name.Length - 5)));

            this.CreateMap<AgeGroup, ProductGroupServiceModel>()
                .ForMember(d => d.Type, cfg => cfg.MapFrom(src => src.GetType().Name.Substring(0, src.GetType().Name.Length - 5)));

            this.CreateMap<OrderRecipientDataModel, ShippingDetails>()
                .ForMember(d => d.RecipientEmailAddress, cfg => cfg.MapFrom(src => src.EmailAddress))
                .ForMember(d => d.RecipientFirstName, cfg => cfg.MapFrom(src => src.FirstName))
                .ForMember(d => d.RecipientLastName, cfg => cfg.MapFrom(src => src.LastName));
        }
    }
}
