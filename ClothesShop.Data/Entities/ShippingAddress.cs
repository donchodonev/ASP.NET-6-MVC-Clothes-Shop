namespace ClothesShop.Data.Entities
{
    using ClothesShop.Data.Interfaces;

    using Miscellaneous;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ShippingAddressConstants;

    public class ShippingAddress : ICreatable, IModifiable, IDeletable
    {
        public ShippingAddress()
        {
            CreatedOn = DateTimeProvider.CurrentTime;
        }

        [Required]
        public int Id { get; set; }

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

        public string? ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
