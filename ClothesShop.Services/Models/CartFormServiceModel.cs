namespace ClothesShop.Services.Models
{
    using ClothesShop.Services.Models.Product;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ShippingDetailsConstants;

    public class CartFormServiceModel
    {
        public CartFormServiceModel()
        {
        }

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        public string Country { get; set; }

        [MinLength(CityNameMinLength)]
        [MaxLength(CityNameMaxLength)]
        public string City { get; set; }

        [MinLength(StreetNameMinLength)]
        [MaxLength(StreetNameMaxLength)]
        public string Street { get; set; }

        [MinLength(PostalCodeMinLength)]
        [MaxLength(PostalCodeMaxLength)]
        public string PostalCode { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public List<ProductCartCookieModel>? Products { get; set; }
    }
}
