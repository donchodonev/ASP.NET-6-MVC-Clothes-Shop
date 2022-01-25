namespace ClothesShop.Services.Models
{
    public interface IOrderValidationResult
    {
        public bool IsValid { get; set; }

        public int ProductId { get; set; }

        public string Message { get; set; }
    }
}
