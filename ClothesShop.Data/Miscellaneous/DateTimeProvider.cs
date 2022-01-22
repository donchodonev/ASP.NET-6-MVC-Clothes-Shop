namespace ClothesShop.Data.Miscellaneous
{
    public static class DateTimeProvider
    {
        public static DateTime CurrentTime => DateTime.UtcNow;

        public static TimeSpan CookieMaxAge => new TimeSpan(3,0,0,0); // 3 days
    }
}
