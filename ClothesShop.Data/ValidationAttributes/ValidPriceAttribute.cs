using System.ComponentModel.DataAnnotations;

namespace ClothesShop.Data.ValidationAttributes
{
    public class ValidPriceAttribute : ValidationAttribute
    {
        private readonly decimal minValue;
        private readonly decimal maxValue;

        public ValidPriceAttribute(string minValue, string maxValue)
        {
            this.minValue = decimal.Parse(minValue);
            this.maxValue = decimal.Parse(maxValue);
        }

        public override bool IsValid(object? value)
        {
            decimal price = decimal.Parse(value.ToString());

            return price > minValue && price < maxValue;
        }
    }
}
