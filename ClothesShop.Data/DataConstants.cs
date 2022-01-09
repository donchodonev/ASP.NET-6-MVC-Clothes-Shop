namespace ClothesShop.Data
{
    public static class DataConstants
    {
        public class Product
        {
            public const int ProductNameMaxLength = 200;

            public const int ProductNameMinLength = 10;

            public const double ProductMinPrice = 0.0;

            public const string DecimalMaxValue = "79228162514264337593543950335";

            public const string Zero = "0";

            public const int MinQuantity = 0;

            public const int MaxQuantity = int.MaxValue;

            public const int DescriptionMinLength = 20;

            public const int DescriptionMaxLength = 500;

            public const int ManufacturerNameMinLength = 2;

            public const int ManufacturerNameMaxLength = 100;
        }

        public class Discount
        {
            public const int PercentageMinValue = 0;
            public const int PercentageMaxValue = 100;
        }

        public class ProductCategory
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;
        }
    }
}
