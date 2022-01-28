namespace ClothesShop.Controllers.Models
{
    using ClothesShop.Controllers.Models.Product;

    public class OrderDetailsViewModel
    {
        public List<ProductOrderDetailsViewModel> Products { get; set; }

        public List<OrderShippingDetailsViewModel> ShippingDetails { get; set; }
    }
}
