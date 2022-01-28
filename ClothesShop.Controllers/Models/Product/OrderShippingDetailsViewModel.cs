namespace ClothesShop.Controllers.Models.Product
{
    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ShippingDetailsConstants;

    public class OrderShippingDetailsViewModel
    {
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

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Required]
        public string RecipientFirstName { get; set; }

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Required]
        public string RecipientLastName { get; set; }

        [EmailAddress]
        public string RecipientEmailAddress { get; set; }
    }
}
