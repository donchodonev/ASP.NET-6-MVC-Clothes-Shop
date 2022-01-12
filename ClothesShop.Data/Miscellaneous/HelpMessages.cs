namespace ClothesShop.Data.Miscellaneous
{
    using static ClothesShop.Data.Miscellaneous.DataConstants.ProductConstants;

    public static class HelpMessages
    {
        public static class Success
        {

        }
        public static class Error
        {
            public static string InvalidPrice => $"Price must be greater than {Zero} and under {DecimalMaxValue}";
        }
    }
}
