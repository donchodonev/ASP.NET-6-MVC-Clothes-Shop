namespace ClothesShop.Controllers.Infrastructure
{
    using AutoMapper;

    using ClothesShop.Controllers.Models;
    using ClothesShop.Controllers.Models.Product;
    using ClothesShop.Data.Entities;
    using ClothesShop.Services.Models.Product;

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
                    new Size() {Value = "XS",Count = src.XS},
                    new Size() {Value = "S",Count = src.S},
                    new Size() {Value = "M",Count = src.M},
                    new Size() {Value = "L",Count = src.L},
                    new Size() {Value = "XL",Count = src.XL},
                    new Size() {Value = "XXL",Count = src.XXL}
                }));

            CreateMap<Product, AllProductViewModel>();

            CreateMap<ProductsControllerQueryFilter, ProductsServiceQueryFilter>()
                .ForMember(d => d.GenderId, cfg => cfg.MapFrom(src => (int)src.GenderOptions))
                .ForMember(d => d.AgeGroupId, cfg => cfg.MapFrom(src => (int)src.AgeOptions))
                .ForMember(d => d.RatingValue, cfg => cfg.MapFrom(src => (int)src.RatingOptions));

            CreateMap<AllProductViewModel, ProductCartCookieModel>();

            CreateMap<Size, SizeWithQuantitySelectListItem>()
                .ForMember(d => d.Text, cfg => cfg.MapFrom(src => src.Value))
                .ForMember(d => d.Value, cfg => cfg.MapFrom(src => src.Id));

            CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(d => d.Sizes, cfg => cfg.MapFrom(src => src.Sizes.Where(x => x.Count > 0)));

            CreateMap<ProductCartCookieModel, ProductCartServiceModel>();

            CreateMap<OrderPurchase, ProductOrderDetailsViewModel>()
                .ForMember(d => d.ProductId, cfg => cfg.MapFrom(src => src.Purchase.ProductId))
                .ForMember(d => d.Count, cfg => cfg.MapFrom(src => src.Purchase.Count))
                .ForMember(d => d.Price, cfg => cfg.MapFrom(src => src.Purchase.Price));

            CreateMap<Purchase, PurchaseDetailsViewModel>()
                .ForMember(d => d.SizeText, cfg => cfg.MapFrom(src => src.Size.Value));

            CreateMap<ShippingDetails, PurchaseShippingDetailsViewModel>();
        }
    }
}
