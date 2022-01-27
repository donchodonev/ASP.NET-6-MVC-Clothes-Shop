namespace ClothesShop.Services.Models
{
    using ClothesShop.Services.Contracts;

    public class OrderValidationResult : IOrderValidationResult
    {
        public OrderValidationResult(bool isValid, int productId, string message)
        {
            IsValid = isValid;
            ProductId = productId;
            Message = message;
        }

        public bool IsValid { get; set; }

        public int ProductId { get; set; }

        public string Message { get; set; }
    }
}
