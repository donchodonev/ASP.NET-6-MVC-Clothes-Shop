﻿namespace ClothesShop.Services.Models
{
    using ClothesShop.Services.Models.Product;

    using System.ComponentModel.DataAnnotations;

    using static ClothesShop.Data.Miscellaneous.DataConstants.ShippingDetailsConstants;

    public class CartFormServiceModel
    {
        public CartFormServiceModel()
        {
        }

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

        public List<ProductCartCookieModel>? Products { get; set; }
    }
}
