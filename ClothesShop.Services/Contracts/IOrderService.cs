namespace ClothesShop.Services.Contracts
{
    using ClothesShop.Services.Models;
    using ClothesShop.Services.Models.Product;

    using Microsoft.AspNetCore.Http;

    public interface IOrderService
    {
        public Task<string> CreateOrderAsync(ProductAndSizeServiceModel[] productAndSizeIds, HttpContext context, OrderRecipientDataModel recipientData,string clientId = null);
    }
}
