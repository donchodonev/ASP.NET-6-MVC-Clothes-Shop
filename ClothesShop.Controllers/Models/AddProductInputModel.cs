namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Data.ValidationAttributes;
    using ClothesShop.Services;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants;
    using static ClothesShop.Data.Miscellaneous.HelpMessages.Error;

    public class AddProductInputModel
    {
        [Required]
        [MaxLength(ProductConstants.ProductNameMaxLength)]
        [MinLength(ProductConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Price(ProductConstants.Zero, ProductConstants.DecimalMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(ProductConstants.MinQuantity, ProductConstants.MaxQuantity)]
        public int Quantity { get; set; }

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
        public int SizeXS { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int SizeS { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int SizeM { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int SizeL { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int SizeXL { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = NegativeProductSizeQuantity)]
        public int SizeXXL { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = InvalidProductSizeCount)]
        public int IsSizeCountValid =>
            SizeXS +
            SizeS +
            SizeM +
            SizeL +
            SizeXL +
            SizeXXL;

        public async Task<AddProductInputModel> CreateOptionsAsync(IProductService products, IGenderService genders, IAgeGroupService ageGroups)
        {
            CategoryOptions = await products.GetCategoriesAsync<CategorySelectListItem>();
            GenderGroupOptions = await genders.AllAsync<GenderGroupSelectListItem>();
            AgeGroupOptions = await ageGroups.AllAsync<AgeGroupSelectListItem>();

            return this;
        }
    }
}
