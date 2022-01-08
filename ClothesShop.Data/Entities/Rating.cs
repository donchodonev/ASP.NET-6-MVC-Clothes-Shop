using ClothesShop.Data.Enums;

namespace ClothesShop.Data.Entities
{
    public class Rating
    {
        public Rating(RatingValue value)
        {
            Value = value;
        }
        public RatingValue Value { get; set; }
    }
}