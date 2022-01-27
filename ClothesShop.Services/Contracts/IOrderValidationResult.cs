namespace ClothesShop.Services.Contracts
{
    public interface IOrderValidationResult
    {
        public bool IsValid { get; set; }

        public int ProductId { get; set; }

        public string Message { get; set; }
    }
}
