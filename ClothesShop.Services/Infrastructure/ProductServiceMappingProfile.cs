namespace ClothesShop.Services.Infrastructure
{
    using AutoMapper;

    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models;

    public class ProductServiceMappingProfile : Profile
    {
       public ProductServiceMappingProfile()
        {
            this.CreateMap<Product, ProductAllServiceModel>().ReverseMap();

            this.CreateMap<ProductAddServiceModel, Product>().ReverseMap();

        }
    }
}
