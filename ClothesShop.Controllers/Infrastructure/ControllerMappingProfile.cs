namespace ClothesShop.Controllers.Infrastructure
{
    using AutoMapper;

    using ClothesShop.Data.Entities;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<ProductCategory, SelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Name))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Name));
        }
    }
}
