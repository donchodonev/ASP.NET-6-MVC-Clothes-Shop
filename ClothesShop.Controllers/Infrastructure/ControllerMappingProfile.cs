namespace ClothesShop.Controllers.Infrastructure
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;
    using ClothesShop.Data.Entities;

    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<ProductCategory, CategorySelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Name))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Name));

            CreateMap<Size, SizeSelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Value))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Value));

            CreateMap<GenderGroup, GenderGroupSelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Name))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Name));
        }
    }
}
