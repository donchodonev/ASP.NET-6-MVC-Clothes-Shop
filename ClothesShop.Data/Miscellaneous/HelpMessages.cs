namespace ClothesShop.Data.Miscellaneous
{
    using static ClothesShop.Data.Miscellaneous.DataConstants.ProductConstants;

    public static class HelpMessages
    {
        public class Success
        {

        }
        public class Error
        {
            public const string InvalidPrice = $"Price must be greater than ${Zero} and under ${DecimalMaxValue}";

            public const string NegativeProductSizeQuantity = "Quantity cannot be less than 0";

            public const string InvalidProductSizeCount = "The overall size types' total quantity count must be greater than 0. Please ensure your data is correct and re-submit it";
        }
    }
}
