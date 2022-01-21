namespace ClothesShop.Data.Miscellaneous
{
    public static class DataConstants
    {
        public class ProductConstants
        {
            public const int ProductNameMaxLength = 200;

            public const int ProductNameMinLength = 10;

            public const string ProductMinPrice = "0.01";

            public const string ProductMaxPrice = "79228162514264337593543950335";

            public const string Zero = "0";

            public const int MinQuantity = 1;

            public const int MaxQuantity = int.MaxValue;

            public const int DescriptionMinLength = 20;

            public const int DescriptionMaxLength = 500;

            public const int ManufacturerNameMinLength = 2;

            public const int ManufacturerNameMaxLength = 100;
        }

        public class DiscountConstants
        {
            public const int PercentageMinValue = 0;
            public const int PercentageMaxValue = 100;
        }

        public class ProductCategoryConstants
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;
        }

        public class ClientConstants
        {
            public const int MinAge = 0;
            public const int MaxAge = 150;
            public const string AdminRoleName = "Administrator";
        }

        public class ShippingAddressConstants
        {
            public const int CountryNameMinLength = 3;
            public const int CountryNameMaxLength = 100;

            public const int CityNameMinLength = 3;
            public const int CityNameMaxLength = 100;

            public const int StreetNameMinLength = 3;
            public const int StreetNameMaxLength = 100;

            public const int PostalCodeMinLength = 3;
            public const int PostalCodeMaxLength = 10;
        }

        public class SizeConstants
        {
            public const int SizeNameMinLength = 2;
            public const int SizeNameMaxLength = 10;
        }

        public class AgeGroupConstants
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 20;
        }

        public class ClubCardTierConstants
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 20;
        }

        public class GenderGroupConstants
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 20;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 300;
        }
    }
}
