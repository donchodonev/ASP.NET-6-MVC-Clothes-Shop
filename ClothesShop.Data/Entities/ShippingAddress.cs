namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.DataConstants.ShippingAddress;
    public class ShippingAddress : ICreatable, IModifiable, IDeletable
    {
        [Required]
        public int Id { get; set; }

        [Range(CountryNameMinLength,CountryNameMaxLength)]
        public string Country { get; set; }

        [Range(CityNameMinLength, CityNameMaxLength)]
        public string City { get; set; }

        [Range(StreetNameMinLength, StreetNameMaxLength)]
        public string Street { get; set; }

        [Range(PostalCodeMinLength, PostalCodeMaxLength)]
        public string PostalCode { get; set; }

        public string ClientId { get; set; }

        public Client Client { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
