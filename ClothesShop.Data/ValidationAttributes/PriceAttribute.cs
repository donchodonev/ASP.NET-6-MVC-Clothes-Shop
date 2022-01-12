namespace ClothesShop.Data.ValidationAttributes
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using static ClothesShop.Data.Miscellaneous.HelpMessages;

    public class PriceAttribute : ValidationAttribute, IClientModelValidator
    {
        public PriceAttribute(string minValue, string maxValue)
        {
            MinValue = Decimal.Parse(minValue);
            MaxValue = Decimal.Parse(maxValue);
        }

        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-Price", GetErrorMessage());

            string minValue = MinValue.ToString(CultureInfo.InvariantCulture);
            string maxValue = MaxValue.ToString(CultureInfo.InvariantCulture);

            MergeAttribute(context.Attributes, "data-val-Price-minPrice", minValue);
            MergeAttribute(context.Attributes, "data-val-Price-maxPrice", maxValue);
        }


        public string GetErrorMessage() => Error.InvalidPrice;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            decimal price = decimal.Parse(value.ToString());

            if (price > MinValue && price < MaxValue)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }
    }
}
