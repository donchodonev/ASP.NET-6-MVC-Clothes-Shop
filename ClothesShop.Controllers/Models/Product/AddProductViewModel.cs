namespace ClothesShop.Controllers.Models.Product
{
    using ClothesShop.Data.ValidationAttributes;
    using ClothesShop.Services.Contracts;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants;
    using static ClothesShop.Data.Miscellaneous.HelpMessages.Error;

    public class AddProductViewModel
    {
        [Required]
        [MaxLength(ProductConstants.ProductNameMaxLength)]
        [MinLength(ProductConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Price(ProductConstants.ProductMinPrice, ProductConstants.ProductMaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [MinLength(ProductConstants.DescriptionMinLength)]
        [MaxLength(ProductConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(ProductConstants.ManufacturerNameMinLength)]
        [MaxLength(ProductConstants.ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; }

        public IEnumerable<CategorySelectListItem>? CategoryOptions { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<GenderGroupSelectListItem>? GenderGroupOptions { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int GenderGroupId { get; set; }

        public IEnumerable<AgeGroupSelectListItem>? AgeGroupOptions { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int AgeGroupId { get; set; }

        [Url]
        [Required]
        public string ImageURL { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int XS { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int S { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int M { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int L { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int XL { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int XXL { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = InvalidProductSizeCount)]
        public int IsSizeCountValid =>
            XS +
            S +
            M +
            L +
            XL +
            XXL;

        public async Task<AddProductViewModel> CreateOptionsAsync(IProductService products, IGenderService genders, IAgeGroupService ageGroups)
        {
            CategoryOptions = await products.GetCategoriesAsync<CategorySelectListItem>();
            GenderGroupOptions = await genders.AllAsync<GenderGroupSelectListItem>();
            AgeGroupOptions = await ageGroups.AllAsync<AgeGroupSelectListItem>();

            return this;
        }
    }
}
