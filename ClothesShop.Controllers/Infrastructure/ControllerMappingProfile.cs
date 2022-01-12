namespace ClothesShop.Controllers.Infrastructure
{
    using AutoMapper;

    using ClothesShop.Controllers.Models.Category;
    using ClothesShop.Data.Entities;

    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<ProductCategory, CategorySelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Name))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Name));
        }
    }
}
