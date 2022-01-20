namespace ClothesShop.Controllers.Infrastructure
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models;

    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<ProductCategory, CategorySelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Name));

            CreateMap<Size, SizeSelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Value));

            CreateMap<GenderGroup, GenderGroupSelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Name));

            CreateMap<AgeGroup, AgeGroupSelectListItem>()
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Name));

            CreateMap<AddProductViewModel, ProductAddServiceModel>()
                .ForMember(d => d.Sizes, cfg => cfg.MapFrom(src => new HashSet<Size>()
                {
                    new Size() {Value = "SizeXS",Count = src.SizeXS},
                    new Size() {Value = "SizeS",Count = src.SizeS},
                    new Size() {Value = "SizeM",Count = src.SizeM},
                    new Size() {Value = "SizeL",Count = src.SizeL},
                    new Size() {Value = "SizeXL",Count = src.SizeXL},
                    new Size() {Value = "SizeXXL",Count = src.SizeXXL}
                }));

            CreateMap<Product, AllProductViewModel>();

            CreateMap<ProductsControllerQueryFilter, ProductsServiceQueryFilter>()
                .ForMember(d => d.GenderId,cfg => cfg.MapFrom(src => (int)src.GenderOptions))
                .ForMember(d => d.AgeGroupId,cfg => cfg.MapFrom(src => (int)src.AgeOptions))
                .ForMember(d => d.RatingValue,cfg => cfg.MapFrom(src => (int)src.RatingOptions));

            CreateMap<AllProductViewModel, ProductCartModel>();
        }
    }
}
